using eDnevnik.Model.Requests;


namespace eDnevnik.Services.IServices
{
    public interface IKorisnikService : ICRUDService<Model.Models.Korisnik, Model.SearchObjects.KorisnikSearchObject, Model.Requests.KorisniciInsertRequest, Model.Requests.KorisniciUpdateRequest>
    {
    }
}
