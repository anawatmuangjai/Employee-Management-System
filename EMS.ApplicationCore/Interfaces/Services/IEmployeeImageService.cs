using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeImageService
    {
        Task<EmployeeImageModel> GetByEmployeeId(string employeeId);
        Task<EmployeeImageModel> AddAsync(EmployeeImageModel model);
        Task UpdateAsync(EmployeeImageModel model);
        Task<bool> ExistsAsync(string employeeId);
    }
}
