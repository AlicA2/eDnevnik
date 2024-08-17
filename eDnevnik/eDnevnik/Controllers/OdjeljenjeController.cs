using eDnevnik.Model;
using eDnevnik.Model.Models;
using eDnevnik.Model.Requests;
using eDnevnik.Model.SearchObjects;
using eDnevnik.Services;
using eDnevnik.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eDnevnik.Controllers
{
    [ApiController]
    public class OdjeljenjeController : BaseCRUDController<Model.Models.Odjeljenje, Model.SearchObjects.OdjeljenjeSearchObject, Model.Requests.OdjeljenjeInsertRequest, Model.Requests.OdjeljenjeUpdateRequest, Model.Requests.OdjeljenjeDeleteRequest>
    {
        private readonly IOdjeljenjeService _odjeljenjeService;

        public OdjeljenjeController(ILogger<BaseController<Odjeljenje, OdjeljenjeSearchObject>> logger, IOdjeljenjeService service) : base(logger, service)
        {
            _odjeljenjeService = service;
        }

        [HttpPost("AddStudentToDepartment")]
        public async Task<IActionResult> AddStudentToDepartment(int odjeljenjeID, int korisnikID)
        {
            try
            {
                var result = await _odjeljenjeService.AddStudentToDepartment(odjeljenjeID, korisnikID);
                if (result)
                {
                    return Ok("Student successfully added to the department.");
                }
                return BadRequest("Unable to add student to the department.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveStudentFromDepartment")]
        public async Task<IActionResult> RemoveStudentFromDepartment(int odjeljenjeID, int korisnikID)
        {
            try
            {
                var result = await _odjeljenjeService.RemoveStudentFromDepartment(odjeljenjeID, korisnikID);
                if (result)
                {
                    return Ok("Student successfully removed from the department.");
                }
                return BadRequest("Unable to remove student from the department.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("WithStudents")]
        public async Task<PagedResult<Odjeljenje>> GetWithStudents([FromQuery] OdjeljenjeSearchObject search)
        {
            if (search == null)
            {
                search = new OdjeljenjeSearchObject();
            }

            search.isUceniciIncluded = true;

            return await _service.Get(search);
        }
    }
}
