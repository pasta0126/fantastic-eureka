using ApiTest.Models;
using ApiTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadRepository _repo;

        public ActividadesController(IActividadRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadModel>>> GetAll()
        {
            return new ObjectResult(await _repo.GetAllActividades());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadModel>> Get(Guid id)
        {
            var actividad = await _repo.GetActividad(id);

            if (actividad == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(actividad);
        }

        [HttpPost]
        public async Task<ActionResult<ActividadModel>> Post([FromBody] ActividadModel model)
        {
            model.Id = _repo.GetNewActividadId();

            var modelResult = await _repo.Create(model);

            return new OkObjectResult(modelResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActividadModel>> Put(Guid id, [FromBody] ActividadModel model)
        {
            var modelFromDb = await _repo.GetActividad(id);

            if (modelFromDb == null)
            {
                return new NotFoundResult();
            }

            model.Id = modelFromDb.Id;
            model.InternalId = modelFromDb.InternalId;

            var response = await _repo.Update(model);

            if (response)
            {
                return new OkObjectResult(model);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var post = await _repo.GetActividad(id);

            if (post == null)
            {
                return new NotFoundResult();
            }

            var response = await _repo.Delete(id);
            
            if (response)
            {
                return new OkResult();
            }

            return new BadRequestResult();

        }
    }
}
