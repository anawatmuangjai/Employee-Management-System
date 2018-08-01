using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeAddressService
    {
        Task<EmployeeAddressModel> AddAsync(EmployeeAddressModel model);
        Task UpdateAsync(EmployeeAddressModel model);
        Task DeleteAsync(int id);
    }
}
