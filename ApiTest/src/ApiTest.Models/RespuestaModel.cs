using System;

namespace ApiTest.Models
{
    public class RespuestaModel
    {
        public Guid IdPregunta { get; set; }
        public string RespuestaEsperada { get; set; }
        public string RespuestaProporcionada { get; set; }
        public bool IsOk { get; set; }
    }
}
