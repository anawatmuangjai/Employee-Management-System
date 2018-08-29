using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobPositionService
    {
        Task<JobPositionModel> GetByIdAsync(int id);
        Task<List<JobPositionModel>> GetAllAsync();
        Task<List<JobPositionModel>> GetByNameAsync(string name);
        Task AddAsync(JobPositionModel model);
        Task UpdateAsync(JobPositionModel model);
        Task DeleteAsync(int id);
    }
}
