using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeStateService
    {
        Task<bool> ExistsAsync(string employeeId);
        Task<EmployeeStateModel> AddAsync(EmployeeStateModel model);
        Task UpdateAsync(EmployeeStateModel model);
        Task DeleteAsync(int id);
    }
}
