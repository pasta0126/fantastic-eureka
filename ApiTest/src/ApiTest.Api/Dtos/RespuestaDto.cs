using System;

namespace ApiTest.Api.Dtos
{
    public class RespuestaDto
    {
        public Guid IdPregunta { get; set; }
        public string RespuestaEsperada { get; set; }
        public string RespuestaProporcionada { get; set; }
        public bool RespuestaOk { get; set; }
    }
}
