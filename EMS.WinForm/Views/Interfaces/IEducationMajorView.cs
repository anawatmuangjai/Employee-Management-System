using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IEducationMajorView : IView
    {
        int MajorId { get; set; }
        int DegreeId { get; set; }
        string MajorName { get; set; }
        string MajorNameThai { get; set; }
        EducationMajorModel SelectedMajor { get; set; }
        IList<EducationDegreeModel> EducationDegrees { set; }
        IList<EducationMajorModel> EducationMajors { set; }
        EducationMajorPresenter Presenter { set; }
    }
}
