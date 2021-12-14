using System;

namespace ApiTest.Models
{
    public class AlumnoModel : ModelBase
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
