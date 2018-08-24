﻿using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEducationMajorService
    {
        Task<EducationMajorModel> GetByIdAsync(int id);
        Task<List<EducationMajorModel>> GetAllAsync();
        Task<List<EducationMajorModel>> GetByNameAsync(string name);
        Task AddAsync(EducationMajorModel model);
        Task UpdateAsync(EducationMajorModel model);
        Task DeleteAsync(int id);
    }
}
