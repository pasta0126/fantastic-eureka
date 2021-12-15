using System;

namespace ApiTest.Api.Dtos
{
    public class NotaDto
    {
        public Guid IdActividad { get; set; }
        public int VecesRealzada { get; set; }
        public double Nota { get; set; }
    }
}
