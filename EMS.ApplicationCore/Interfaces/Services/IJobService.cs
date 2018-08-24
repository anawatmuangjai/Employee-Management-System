using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IJobService
    {
        Task<JobTitleModel> GetByIdAsync(int id);
        Task<List<JobTitleModel>> GetAllAsync();
        Task<List<JobTitleModel>> GetByNameAsync(string name);
        Task AddAsync(JobTitleModel model);
        Task UpdateAsync(JobTitleModel model);
        Task DeleteAsync(int id);
    }
}
