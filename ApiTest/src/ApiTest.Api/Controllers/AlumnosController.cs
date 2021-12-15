using ApiTest.Api.Dtos;
using ApiTest.Models;
using ApiTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoRepository _alumnoRepo;
        private readonly ISesionRepository _sesionRepo;

        public AlumnosController(IAlumnoRepository alumnoRepo, ISesionRepository sesionRepo)
        {
            _alumnoRepo = alumnoRepo;
            _sesionRepo = sesionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnoModel>>> GetAll()
        {
            return new ObjectResult(await _alumnoRepo.GetAllAlumnos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoModel>> Get(Guid id)
        {
            var alumno = await _alumnoRepo.GetAlumno(id);

            if (alumno == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(alumno);
        }

        [HttpGet("{idAlumno}/Sesiones/{idSesion}")]
        public async Task<ActionResult<List<NotaDto>>> GetNotaActividad(Guid idAlumno, Guid idSesion)
        {
            var result = new List<NotaDto>();
            var sesion = await _sesionRepo.GetSesion(idSesion);

            foreach (var actividad in sesion.Actividades)
            {
                var nota = _sesionRepo.EvaluacionPorActividades(sesion.Actividades);
                var vecesRealizada = sesion.Actividades.Where(w => w.IdActividad == actividad.IdActividad).Count();

                result.Add(new NotaDto()
                {
                    IdActividad = actividad.IdActividad,
                    Nota = nota,
                    VecesRealzada = vecesRealizada,
                });
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<AlumnoModel>> Post([FromBody] AlumnoModel model)
        {
            model.Id = _alumnoRepo.GetNewAlumnoId();

            var modelResult = await _alumnoRepo.Create(model);

            return new OkObjectResult(modelResult);
        }

        [HttpPost("{idAlumno}/Actividades/{idActividad}/Respuestas")]
        public async Task<ActionResult<SesionModel>> PostRespuestasAlumno(Guid idAlumno, Guid idActividad, [FromBody] List<ActividadSesionDto> model)
        {
            var actividades = new List<ActividadSesionModel>();

            foreach (var item in model)
            {
                var targetList = item.Respuestas.Select(x => new RespuestaModel()
                {
                    IdPregunta = x.IdPregunta,
                    IsOk = x.IsOk,
                    RespuestaEsperada = x.RespuestaEsperada,
                    RespuestaProporcionada = x.RespuestaProporcionada,
                }).ToList();

                actividades.Add(new ActividadSesionModel()
                {
                    Competencia = item.competencia,
                    IdActividad = item.IdActividad,
                    Respuestas = targetList,
                    Tipo = item.Tipo,
                });
            }

            var sesion = new SesionModel()
            {
                Actividades = actividades,
                Id = _sesionRepo.GetNewSesionId(),
                IdAlumno = idAlumno,
            };

            return await _sesionRepo.Create(sesion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlumnoModel>> Put(Guid id, [FromBody] AlumnoModel model)
        {
            var modelFromDb = await _alumnoRepo.GetAlumno(id);

            if (modelFromDb == null)
            {
                return new NotFoundResult();
            }

            model.Id = modelFromDb.Id;
            model.InternalId = modelFromDb.InternalId;

            var response = await _alumnoRepo.Update(model);

            if (response)
            {
                return new OkObjectResult(model);
            }

            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var post = await _alumnoRepo.GetAlumno(id);

            if (post == null)
            {
                return new NotFoundResult();
            }

            var response = await _alumnoRepo.Delete(id);

            if (response)
            {
                return new OkResult();
            }

            return new BadRequestResult();

        }
    }
}
