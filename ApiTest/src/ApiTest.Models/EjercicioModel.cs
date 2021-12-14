using System;
using System.Collections.Generic;

namespace ApiTest.Models
{
    public class EjercicioModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<PreguntaModel> Preguntas { get; set; }
    }
}
