using ApiTest.Models;
using ApiTest.Models.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Repository
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly IActividadContext _context;

        public ActividadRepository(IActividadContext context)
        {
            _context = context;
        }

        public async Task<ActividadModel> Create(ActividadModel model)
        {
            await _context.Actividades.InsertOneAsync(model);

            return await GetActividad(model.Id);
        }

        public async Task<bool> Delete(Guid id)
        {
            FilterDefinition<ActividadModel> filter = Builders<ActividadModel>.Filter.Eq(m => m.Id, id);
            DeleteResult result = await _context.Actividades.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<ActividadModel>> GetAllAlumnos()
        {
            return await _context.Actividades.Find(_ => true).ToListAsync();
        }

        public Task<ActividadModel> GetActividad(Guid id)
        {
            FilterDefinition<ActividadModel> filter = Builders<ActividadModel>.Filter.Eq(m => m.Id, id);

            return _context.Actividades.Find(filter).FirstOrDefaultAsync();
        }

        public Guid GetNewActividadId()
        {
            return Guid.NewGuid();
        }

        public async Task<bool> Update(ActividadModel model)
        {
            ReplaceOneResult result = await _context.Actividades.ReplaceOneAsync(
                filter: g => g.Id == model.Id,
                replacement: model);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
