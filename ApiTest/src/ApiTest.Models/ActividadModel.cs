using ApiTest.Models.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ApiTest.Models
{
    public class ActividadModel : ModelBase
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<EjercicioModel> Ejercicios { get; set; }
        public CompetenciaType Competencia { get; set; }
        public ActividadType Tipo { get; set; }
    }
}
