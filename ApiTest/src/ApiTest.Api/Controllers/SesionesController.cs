using ApiTest.Models;
using ApiTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiTest.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class SesionesController : ControllerBase
    {
        private readonly ISesionRepository _repo;

        public SesionesController(ISesionRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<SesionModel>> Post([FromBody] SesionModel model)
        {
            model.Id = _repo.GetNewSesionId();

            var modelResult = await _repo.Create(model);

            return new OkObjectResult(modelResult);
        }
    }
}
