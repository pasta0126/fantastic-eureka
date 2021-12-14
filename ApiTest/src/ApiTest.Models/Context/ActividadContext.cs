using ApiTest.Models.Config;
using MongoDB.Driver;

namespace ApiTest.Models.Context
{
    public class ActividadContext
    {
        private readonly IMongoDatabase _db;

        public ActividadContext(MongoDbConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<ActividadModel> Actividades => _db.GetCollection<ActividadModel>("Actividades");
    }
}
