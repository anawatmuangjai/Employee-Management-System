using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeStateService
    {
        Task<List<EmployeeStateModel>> GetAllAsync();
        Task<EmployeeStateModel> GetByEmployeeId(string employeeId);
        Task<EmployeeStateModel> AddAsync(EmployeeStateModel model);
        Task<bool> ExistsAsync(string employeeId);
        Task<int> CountShiftAsync(int shiftId);
        Task UpdateAsync(EmployeeStateModel model);
        Task DeleteAsync(int id);
    }
}
