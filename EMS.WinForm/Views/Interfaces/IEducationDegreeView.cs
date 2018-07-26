using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System.Collections.Generic;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IEducationDegreeView : IView
    {
        int DegreeId { get; set; }
        string DegreeName { get; set; }
        string DegreeNameThai { get; set; }
        EducationDegreeModel SelectedDegree { get; set; }
        IList<EducationDegreeModel> EducationDegrees { set; }
        EducationDegreePresenter Presenter { set; }
    }
}
