using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<IEnumerable<DepartmentModel>> GetByNameAsync(string name);
        Task AddAsync(DepartmentModel model);
        Task UpdateAsync(DepartmentModel model);
        Task DeleteAsync(int id);
    }
}
