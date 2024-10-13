

namespace eDnevnik.Services.IServices
{
    public interface IKorisnikService
    {
        Task<int?> GetLoged(string username, string password);

        public Task<Model.Models.Korisnik> Login(string username, string password);
    }
}
