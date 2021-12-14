using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ApiTest.Api.Dtos
{
    public class AlumnoDto
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Evaluacion { get; set; }
    }
}
