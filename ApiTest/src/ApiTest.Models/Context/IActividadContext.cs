using MongoDB.Driver;

namespace ApiTest.Models.Context
{
    public interface IActividadContext
    {
        IMongoCollection<ActividadModel> Actividades { get; }
    }
}
