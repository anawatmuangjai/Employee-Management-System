using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public IEnumerable<EmployeeListModel> Employees { get; set; }
    }
}
