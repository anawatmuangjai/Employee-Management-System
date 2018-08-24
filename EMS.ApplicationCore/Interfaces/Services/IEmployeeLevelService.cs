using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeLevelService
    {
        Task<EmployeeLevelModel> GetByIdAsync(int id);
        Task<List<EmployeeLevelModel>> GetAllAsync();
        Task<List<EmployeeLevelModel>> GetByNameAsync(string name);
        Task AddAsync(EmployeeLevelModel model);
        Task UpdateAsync(EmployeeLevelModel model);
        Task DeleteAsync(int id);
    }
}
