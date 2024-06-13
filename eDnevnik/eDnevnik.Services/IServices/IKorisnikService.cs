using eDnevnik.Model.Requests;

namespace eDnevnik.Services.IServices
{
    public interface IKorisnikService
    {
        Task<List<Model.Models.Korisnik>> Get();
        Model.Models.Korisnik Insert(KorisniciInsertRequest request);
        Model.Models.Korisnik Update(int id, KorisniciUpdateRequest request);
    }
}
