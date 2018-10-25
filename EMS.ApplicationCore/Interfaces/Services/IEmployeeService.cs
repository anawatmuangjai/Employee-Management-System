using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllAsync();
        Task<List<EmployeeModel>> GetByNameAsync(string name);
        Task<List<EmployeeModel>> GetAsync(EmployeeFilter filter);
        Task<EmployeeModel> GetByEmployeeIdAsync(string employeeId);
        Task<EmployeeModel> GetByEmployeeIdWithDetailAsync(string employeeId);
        Task<int> CountTotalEmployeeAsync();
        Task<bool> ExistsAsync(string employeeId);
        Task<EmployeeModel> AddAsync(EmployeeModel model);
        Task UpdateAsync(EmployeeModel model);
        Task DeleteAsync(int id);
    }
}
