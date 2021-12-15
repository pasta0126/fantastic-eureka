using ApiTest.Models.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiTest.Models
{
    public class ActividadModel : ModelBase
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public Guid Id { get; set; }

        [StringLength(50, ErrorMessage = "Max length 50")]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "Max length 100")]
        public string Descripcion { get; set; }

        public List<EjercicioModel> Ejercicios { get; set; }

        [EnumDataType(typeof(CompetenciaType))]
        public CompetenciaType Competencia { get; set; }

        [EnumDataType(typeof(ActividadType))]
        public ActividadType Tipo { get; set; }
    }
}
