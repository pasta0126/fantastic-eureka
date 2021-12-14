using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace ApiTest.Models
{
    public class SesionModel : ModelBase
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public Guid Id { get; set; }
        public Guid IdAlumno { get; set; }
        public List<ActividadSesionModel> Actividades { get; set; }
    }
}
