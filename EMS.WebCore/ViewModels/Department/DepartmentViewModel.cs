using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public IEnumerable<DepartmentModel> Departments { get; set; }
    }
}