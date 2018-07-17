using EMS.Core.Dtos;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface ISectionView
    {
        int SectionID { get; set; }
        int DepartmentID { get; set; }
        string SectionName { get; set; }
        string SectionCode { get; set; }
        string Filter { get; set; }
        SectionDto SelectedSection { get; set; }
        DepartmentDto SelectedDepartment { get; set; }
        IList<SectionDto> Sections { set; }
        IList<DepartmentDto> Departments { set; }
        SectionPresenter Presenter { set; }
    }
}
