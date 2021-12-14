using ApiTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Repository
{
    public interface IActividadRepository
    {
        Task<IEnumerable<ActividadModel>> GetAllAlumnos();
        Task<ActividadModel> GetActividad(Guid id);
        Task<ActividadModel> Create(ActividadModel model);
        Task<bool> Update(ActividadModel todo);
        Task<bool> Delete(Guid id);
        Guid GetNewActividadId();
    }
}
