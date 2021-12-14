using ApiTest.Models.Types;
using System;
using System.Collections.Generic;

namespace ApiTest.Models
{
    public class ActividadModel : ModelBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<EjercicioModel> Ejercicios { get; set; }
        public CompetenciaType Competencia { get; set; }
        public ActividadType Tipo { get; set; }
        public int Nota { get; set; } // TODO: Max 10
        public int? VecesRealizadas { get; set; }
    }
}
