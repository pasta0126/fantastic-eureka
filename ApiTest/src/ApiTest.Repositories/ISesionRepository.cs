﻿using ApiTest.Models;
using System;
using System.Threading.Tasks;

namespace ApiTest.Repositories
{
    public interface ISesionRepository
    {
        Task<SesionModel> GetSesion(Guid id);
        Task<SesionModel> Create(SesionModel model);
        Task<bool> Update(SesionModel model);
        Task<bool> Delete(Guid id);
        Guid GetNewSesionId();
    }
}
