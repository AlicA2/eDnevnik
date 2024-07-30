using eDnevnik.Model.Requests;


namespace eDnevnik.Services.IServices
{
    public interface IKorisnikService : ICRUDService<Model.Models.Korisnik, Model.SearchObjects.KorisnikSearchObject, Model.Requests.KorisniciInsertRequest, Model.Requests.KorisniciUpdateRequest, Model.Requests.KorisniciDeleteRequest>
    {
        Task<int?> GetLoged(string username, string password);

        public Task<Model.Models.Korisnik> Login(string username, string password);
        public Task UpdatePasswordAndUsername(int id, KorisniciUpdateRequestLimited request);
        Task<bool> VerifyOldPassword(int id, string oldPassword);
        Task<(int? korisnikId, string uloga)> GetLogedWithRole(string username, string password);
    }
}
