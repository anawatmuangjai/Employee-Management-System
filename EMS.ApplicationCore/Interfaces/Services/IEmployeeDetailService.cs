using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IEmployeeDetailService
    {
        Task<EmployeeDetailModel> AddAsync(EmployeeDetailModel model);
        Task UpdateAsync(EmployeeDetailModel model);
        Task DeleteAsync(int id);
    }
}
