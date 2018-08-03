using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IEmployeeRegisterService
    {
        Task<RegisterEmployeeViewModel> GetRegisterEmployeeViewModel();
        Task CreateEmployee(RegisterEmployeeViewModel viewModel);
        Task<IEnumerable<SelectListItem>> GetJobTitles();
        Task<IEnumerable<SelectListItem>> GetLevels();
        Task<IEnumerable<SelectListItem>> GetDepartments();
        Task<IEnumerable<SelectListItem>> GetSections();
    }
}
