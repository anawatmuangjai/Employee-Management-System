using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Account;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IAccountService
    {
        Task<EmployeePasswordModel> GetPasswordAsync(string employeeId);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);

        Task<RegisterEmployeeViewModel> GetRegisterEmployeeViewModel();
        Task CreateEmployee(RegisterEmployeeViewModel viewModel);
        Task RegisterEmployee(RegisterViewModel viewModel);

        Task<bool> Exists(string employeeId);
        Task<IEnumerable<SelectListItem>> GetJobTitles();
        Task<IEnumerable<SelectListItem>> GetLevels();
        Task<IEnumerable<SelectListItem>> GetDepartments();
        Task<IEnumerable<SelectListItem>> GetSections();
    }
}
