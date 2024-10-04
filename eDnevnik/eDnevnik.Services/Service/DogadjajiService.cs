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
            var dogadjaj = await _context.Dogadjaji
                .Include(x => x.KorisniciDogadjaji)
                .FirstOrDefaultAsync(x => x.DogadjajId == dogadjajId);

            if (dogadjaj == null)
            {
                throw new Exception($"Dogadjaj with ID {dogadjajId} not found.");
            }

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
                    var tmpData = _context.Dogadjaji.Include(d => d.KorisniciDogadjaji).ToList();

                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData)
                    {
                        if (x.KorisniciDogadjaji.Count > 1)
                        {
                            var distinctDogadjajIds = x.KorisniciDogadjaji.Select(kd => kd.DogadjajId).Distinct().ToList();

                            foreach (var distinctId in distinctDogadjajIds)
                            {
                                var relatedEvents = _context.KorisniciDogadjaji
                                    .Where(kd => kd.DogadjajId != distinctId && kd.KorisnikID != x.KorisniciDogadjaji.First().KorisnikID)
                                    .ToList()
                                    .GroupBy(kd => kd.DogadjajId)
                                    .Where(g => g.Count() >= 2)
                                    .SelectMany(g => g)
                                    .ToList();

                                foreach (var related in relatedEvents)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)distinctId,
                                        CoPurchaseProductID = (uint)related.DogadjajId,
                                    });
                                }
                            }
                        }
                    }

                    var traindata = mlContext.Data.LoadFromEnumerable(data);

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

            var korisnikIds = _context.KorisniciDogadjaji
                .Where(kd => kd.DogadjajId == id)
                .Select(kd => kd.KorisnikID)
                .Distinct()
                .ToList();

            var predictionResult = new List<Tuple<Database.Dogadjaji, float>>();

            var relatedEventIds = _context.KorisniciDogadjaji
                 .Where(kd => korisnikIds.Contains(kd.KorisnikID) && kd.DogadjajId != id)
                 .ToList()
                 .GroupBy(kd => kd.DogadjajId)
                 .Where(g => g.Count() >= 2)
                 .Select(g => g.Key)
                 .ToList();

            foreach (var relatedDogadjajId in relatedEventIds)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(
                    new ProductEntry()
                    {
                        ProductID = (uint)id,
                        CoPurchaseProductID = (uint)relatedDogadjajId
                    });

                var relatedDogadjaj = _context.Dogadjaji.FirstOrDefault(d => d.DogadjajId == relatedDogadjajId);

                predictionResult.Add(new Tuple<Database.Dogadjaji, float>(relatedDogadjaj, prediction.Score));
            }

            var finalResult = predictionResult
                .OrderByDescending(x => x.Item2)
                .Select(x => x.Item1)
                .Take(3)
                .ToList();

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
