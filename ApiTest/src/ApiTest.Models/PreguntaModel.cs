using System;

namespace ApiTest.Models
{
    public class PreguntaModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Respuesta { get; set; }
    }
}
