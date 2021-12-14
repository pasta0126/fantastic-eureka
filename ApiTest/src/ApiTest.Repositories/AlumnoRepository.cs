using ApiTest.Models;
using ApiTest.Models.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly IAlumnoContext _context;

        public AlumnoRepository(IAlumnoContext context)
        {
            _context = context;
        }

        public async Task<AlumnoModel> Create(AlumnoModel model)
        {
            await _context.Alumnos.InsertOneAsync(model);

            return await GetAlumno(model.Id);
        }

        public async Task<bool> Delete(Guid id)
        {
            FilterDefinition<AlumnoModel> filter = Builders<AlumnoModel>.Filter.Eq(m => m.Id, id);
            DeleteResult result = await _context.Alumnos.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<AlumnoModel>> GetAllAlumnos()
        {
            return await _context.Alumnos.Find(_ => true).ToListAsync();
        }

        public Task<AlumnoModel> GetAlumno(Guid id)
        {
            FilterDefinition<AlumnoModel> filter = Builders<AlumnoModel>.Filter.Eq(m => m.Id, id);

            return _context.Alumnos.Find(filter).FirstOrDefaultAsync();
        }

        public Guid GetNewAlumnoId()
        {
            return Guid.NewGuid();
        }

        public async Task<bool> Update(AlumnoModel model)
        {
            ReplaceOneResult result = await _context.Alumnos.ReplaceOneAsync(
                filter: g => g.Id == model.Id,
                replacement: model);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
