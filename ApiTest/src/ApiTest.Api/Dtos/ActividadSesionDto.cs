using ApiTest.Models.Types;
using System;
using System.Collections.Generic;

namespace ApiTest.Api.Dtos
{
    public class ActividadSesionDto
    {
        public Guid IdActividad { get; set; }
        public CompetenciaType competencia { get; set; }
        public ActividadType Tipo { get; set; }
        public List<RespuestaDto> Respuestas { get; set; }
    }
}
