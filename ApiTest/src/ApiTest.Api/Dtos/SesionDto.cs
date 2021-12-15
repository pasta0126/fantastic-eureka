using System;
using System.Collections.Generic;

namespace ApiTest.Api.Dtos
{
    public class SesionDto
    {
        public Guid Id { get; set; }
        public Guid IdAlumno { get; set; }
        public List<ActividadSesionDto> Actividades { get; set; }
    }
}
