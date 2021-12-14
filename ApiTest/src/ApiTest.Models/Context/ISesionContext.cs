using MongoDB.Driver;

namespace ApiTest.Models.Context
{
    public interface ISesionContext
    {
        IMongoCollection<SesionModel> Sesiones { get; }
    }
}
