using ApiTest.Models.Types;
using System;
using System.Collections.Generic;

namespace ApiTest.Models
{
    public class ActividadSesionModel
    {
        public Guid IdActividad { get; set; }
        public CompetenciaType Competencia { get; set; }
        public ActividadType Tipo { get; set; }
        public List<RespuestaModel> Respuestas { get; set; }
    }
}
