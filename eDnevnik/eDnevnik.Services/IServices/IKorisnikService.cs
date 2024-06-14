using eDnevnik.Model.Requests;


namespace eDnevnik.Services.IServices
{
    public interface IKorisnikService : IService<Model.Models.Korisnik, Model.SearchObjects.KorisnikSearchObject>
    {
        //Model.Models.Korisnik Insert(KorisniciInsertRequest request);
        //Model.Models.Korisnik Update(int id, KorisniciUpdateRequest request);
    }
}
