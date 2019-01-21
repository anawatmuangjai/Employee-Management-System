using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public EmployeeFilter FilterModel { get; set; }
        public IEnumerable<EmployeeModel> Employees { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Sections { get; set; }
        public IEnumerable<SelectListItem> Shifts { get; set; }
        public IEnumerable<SelectListItem> Positions { get; set; }
        public IEnumerable<SelectListItem> JobFunctions { get; set; }
        public IEnumerable<SelectListItem> JobLevels { get; set; }
        public IEnumerable<SelectListItem> BusStations { get; set; }
    }
}