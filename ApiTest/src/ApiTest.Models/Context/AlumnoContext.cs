using ApiTest.Models.Config;
using MongoDB.Driver;

namespace ApiTest.Models.Context
{
    public class AlumnoContext : IAlumnoContext
    {
        private readonly IMongoDatabase _db;

        public AlumnoContext(MongoDbConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<AlumnoModel> Alumnos => _db.GetCollection<AlumnoModel>("Alumnos");
    }
}
