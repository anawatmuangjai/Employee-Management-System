using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobFunctionService
    {
        Task<JobFunctionModel> GetByIdAsync(int id);
        Task<List<JobFunctionModel>> GetAllAsync();
        Task<List<JobFunctionModel>> GetByNameAsync(string name);
        Task<List<JobFunctionModel>> GetBySectionIdAsync(int sectionId);
        Task AddAsync(JobFunctionModel model);
        Task UpdateAsync(JobFunctionModel model);
        Task DeleteAsync(int id);
    }
}
