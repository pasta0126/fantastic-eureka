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
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoRepository _repo;

        public AlumnosController(IAlumnoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnoModel>>> GetAll()
        {
            return new ObjectResult(await _repo.GetAllAlumnos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoModel>> Get(Guid id)
        {
            var alumno = await _repo.GetAlumno(id);

            if (alumno == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(alumno);
        }

        [HttpPost]
        public async Task<ActionResult<AlumnoModel>> Post([FromBody] AlumnoModel model)
        {
            model.Id = _repo.GetNewAlumnoId();

            var modelResult = await _repo.Create(model);

            return new OkObjectResult(modelResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlumnoModel>> Put(Guid id, [FromBody] AlumnoModel model)
        {
            var modelFromDb = await _repo.GetAlumno(id);

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
            var post = await _repo.GetAlumno(id);

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
