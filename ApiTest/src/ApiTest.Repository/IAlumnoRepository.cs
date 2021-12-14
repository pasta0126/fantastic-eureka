using ApiTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Repository
{
    public interface IAlumnoRepository
    {
        Task<IEnumerable<AlumnoModel>> GetAllAlumnos();
        Task<AlumnoModel> GetAlumno(Guid id);
        Task<AlumnoModel> Create(AlumnoModel model);
        Task<bool> Update(AlumnoModel todo);
        Task<bool> Delete(Guid id);
        Guid GetNewAlumnoId();
    }
}
