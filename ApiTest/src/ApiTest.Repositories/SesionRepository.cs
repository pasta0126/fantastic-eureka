﻿using ApiTest.Models;
using ApiTest.Models.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Repositories
{
    public class SesionRepository : ISesionRepository
    {
        private readonly ISesionContext _context;

        public SesionRepository(ISesionContext context)
        {
            _context = context;
        }

        public async Task<SesionModel> Create(SesionModel model)
        {
            await _context.Sesiones.InsertOneAsync(model);

            return await GetSesion(model.Id);
        }

        public async Task<bool> Delete(Guid id)
        {
            FilterDefinition<SesionModel> filter = Builders<SesionModel>.Filter.Eq(m => m.Id, id);
            DeleteResult result = await _context.Sesiones.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public Guid GetNewSesionId()
        {
            return Guid.NewGuid();
        }

        public Task<SesionModel> GetSesion(Guid id)
        {
            FilterDefinition<SesionModel> filter = Builders<SesionModel>.Filter.Eq(m => m.Id, id);

            return _context.Sesiones.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(SesionModel model)
        {
            ReplaceOneResult result = await _context.Sesiones.ReplaceOneAsync(
                filter: g => g.Id == model.Id,
                replacement: model);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
