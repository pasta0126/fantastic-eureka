using ApiTest.Models.Config;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTest.Models.Context
{
    public class SesionContext : ISesionContext
    {
        private readonly IMongoDatabase _db;

        public SesionContext(MongoDbConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<SesionModel> Sesiones => _db.GetCollection<SesionModel>("Sesiones");
    }
}
