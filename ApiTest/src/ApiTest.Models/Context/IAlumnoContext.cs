using MongoDB.Driver;

namespace ApiTest.Models.Context
{
    public interface IAlumnoContext
    {
        IMongoCollection<AlumnoModel> Alumnos { get; }
    }
}
