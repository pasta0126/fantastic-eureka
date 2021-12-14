using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiTest.Models
{
    public class ModelBase
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
    }
}
