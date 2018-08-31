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
        Task<EmployeeModel> GetByEmployeeIdAsync(string employeeId);
        Task<EmployeeModel> GetByEmployeeIdWithDetailAsync(string employeeId);
        Task<bool> ExistsAsync(string employeeId);
        Task<EmployeeModel> AddAsync(EmployeeModel model);
        Task UpdateAsync(EmployeeModel model);
        Task DeleteAsync(int id);
    }
}
