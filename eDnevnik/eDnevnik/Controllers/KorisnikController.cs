using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class KorisnikController : BaseCRUDController<Model.Models.Korisnik, Model.SearchObjects.KorisnikSearchObject, Model.Requests.KorisniciInsertRequest, Model.Requests.KorisniciUpdateRequest, Model.Requests.KorisniciDeleteRequest>
    {
        private readonly IKorisnikService _korisnikService;
        public KorisnikController(ILogger<BaseController<Korisnik, Model.SearchObjects.KorisnikSearchObject>> logger, IKorisnikService service) : base(logger, service)
        {
            _korisnikService = service;
        }

        [Authorize(Roles = "admin")]
        public override Task<Korisnik> Insert([FromBody] KorisniciInsertRequest insert)
        {
            return base.Insert(insert);
        }
        [HttpGet("GetLoged")]
        public virtual async Task<IActionResult> GetLoged(string username, string password)
        {
            var korisnikId = await _korisnikService.GetLoged(username, password);
            if (korisnikId != null)
            {
                return Ok(korisnikId);
            }
            else
            {
                return NotFound("Korisnik nije pronađen ili pogrešna lozinka.");
            }
        }
        [HttpPut("UpdatePasswordAndUsername")]
        public virtual async Task<IActionResult> UpdatePasswordAndUsername(int id, string oldPassword, KorisniciUpdateRequestLimited request)
        {
            try
            {
                var isOldPasswordCorrect = await _korisnikService.VerifyOldPassword(id, oldPassword);

                if (!isOldPasswordCorrect)
                {
                    return BadRequest("Stari password nije ispravan.");
                }

                await _korisnikService.UpdatePasswordAndUsername(id, request);
                return Ok("Uspješno ažuriran korisničko ime i/ili lozinka.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom ažuriranja: {ex.Message}");
            }
        }
    } 
}