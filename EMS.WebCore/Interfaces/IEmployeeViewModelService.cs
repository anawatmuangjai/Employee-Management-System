using EMS.WebCore.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IEmployeeViewModelService
    {
        Task<EmployeeViewModel> GetEmployeeList();
        Task<EmployeeProfileViewModel> GetEmployeeProfile(string employeeId);
    }
}
