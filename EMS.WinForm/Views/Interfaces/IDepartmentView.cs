using EMS.Domain.Entities;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IDepartmentView
    {
        int DepartmentId { get; set; }
        string DepartmentName { get; set; }
        string DepartmentCode { get; set; }
        string DepartmentGroup { get; set; }

        string Filter { get; set; }
        MasterDepartment SelectedDepartment { get; set; }
        IList<MasterDepartment> Departments { set; }
        DepartmentPresenter Presenter { set; }
    }
}
