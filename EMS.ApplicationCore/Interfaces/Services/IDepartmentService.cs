using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentModel> GetByIdAsync(int id);
        Task<List<DepartmentModel>> GetAllAsync();
        Task<List<DepartmentModel>> GetByNameAsync(string name);
        Task AddAsync(DepartmentModel model);
        Task UpdateAsync(DepartmentModel model);
        Task DeleteAsync(int id);
    }
}
