using AutoMapper;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services.Database;
using eDnevnik.Services.DogadjajiStateMachine;
using eDnevnik.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.Service
{
    public class DogadjajiService : BaseCRUDService<Model.Models.Dogadjaji, Database.Dogadjaji, DogadjajiSearchObject, DogadjajiInsertRequest, DogadjajiUpdateRequest, DogadjajiDeleteRequest>, IDogadjajiService
    {
        public BaseStateDogadjaji _baseState { get; set; }

        public DogadjajiService(BaseStateDogadjaji baseState, eDnevnikDBContext context, IMapper mapper)
            : base(context, mapper)
        {
            _baseState = baseState;

        }

        public async Task<List<Model.Models.KorisnikDogadjaj>> GetKorisniciDogadjaji(int dogadjajId)
        {
            // Fetch the Dogadjaji entity along with the related KorisniciDogadjaji
            var dogadjaj = await _context.Dogadjaji
                .Include(x => x.KorisniciDogadjaji)
                .FirstOrDefaultAsync(x => x.DogadjajId == dogadjajId);

            // Handle case where the event (dogadjaj) is not found
            if (dogadjaj == null)
            {
                throw new Exception($"Dogadjaj with ID {dogadjajId} not found.");
            }

            // Map the KorisniciDogadjaji collection to the corresponding model
            var korisniciDogadjaji = dogadjaj.KorisniciDogadjaji.ToList();
            return _mapper.Map<List<Model.Models.KorisnikDogadjaj>>(korisniciDogadjaji);
        }


        public override async Task<Model.Models.Dogadjaji> Insert(DogadjajiInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");
            return await state.Insert(insert);
        }

        public override async Task<Model.Models.Dogadjaji> Update(int id, DogadjajiUpdateRequest update)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Update(id, update);
        }

        public async Task<Model.Models.Dogadjaji> Activate(int id)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Activate(id);
        }
        public async Task<Model.Models.Dogadjaji> Hide(int id)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity.StateMachine);
            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Dogadjaji.FindAsync(id);
            var state = _baseState.CreateState(entity?.StateMachine ?? "initial");
            return await state.AllowedActions();
        }

        public override IQueryable<Dogadjaji> AddFilter(IQueryable<Dogadjaji> query, DogadjajiSearchObject? search = null)
        {
            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.NazivDogadjaja))
                {
                    query = query.Where(x => x.NazivDogadjaja.StartsWith(search.NazivDogadjaja));
                }
                if (!string.IsNullOrWhiteSpace(search.OpisDogadjaja))
                {
                    query = query.Where(x => x.OpisDogadjaja.Contains(search.OpisDogadjaja));
                }
                if (search.DogadjajId.HasValue)
                {
                    query = query.Where(x => x.DogadjajId == search.DogadjajId.Value);
                }
                if (search.SkolaID.HasValue)
                {
                    query = query.Where(x => x.SkolaID == search.SkolaID.Value);
                }
            }

            return base.AddFilter(query, search);
        }

        static MLContext mlContext = null;
        static object isLocked = new object();
        static ITransformer model = null;

        public List<Model.Models.Dogadjaji> Recommend(int id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = _context.Dogadjaji.Include("KorisniciDogadjaj").ToList();

                    var data = new List<ProductEntry>();

                    Console.WriteLine($"Total Dogadjaji: {tmpData.Count}");

                    foreach (var x in tmpData)
                    {
                        Console.WriteLine($"DogadjajId: {x.DogadjajId}, KorisniciDogadjaji Count: {x.KorisniciDogadjaji.Count}");

                        if (x.KorisniciDogadjaji.Count > 1)
                        {
                            var distinctItemId = x.KorisniciDogadjaji.Select(y => y.DogadjajId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.KorisniciDogadjaji.Where(z => z.DogadjajId != y);

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.DogadjajId,
                                    });
                                }
                            });
                        }
                    }

                    // Debug: Check if data has been populated
                    Console.WriteLine($"Data Count for training: {data.Count}");

                    if (data == null || !data.Any())
                    {
                        throw new InvalidOperationException("No valid instances found for training data.");
                    }

                    IDataView traindata = null;

                    try
                    {
                        traindata = mlContext.Data.LoadFromEnumerable(data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading data: {ex.Message}");
                        throw;
                    }

                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;

                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }
            }

            var products = _context.Dogadjaji.Where(x => x.DogadjajId != id);

            var predictionResult = new List<Tuple<Database.Dogadjaji, float>>();

            var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
            foreach (var product in products)
            {
                var prediction = predictionEngine.Predict(
                                     new ProductEntry()
                                     {
                                         ProductID = (uint)id,
                                         CoPurchaseProductID = (uint)product.DogadjajId
                                     });
                predictionResult.Add(new Tuple<Database.Dogadjaji, float>(product, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).ToList();

            return _mapper.Map<List<Model.Models.Dogadjaji>>(finalResult);
        }

    }
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }

        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}
