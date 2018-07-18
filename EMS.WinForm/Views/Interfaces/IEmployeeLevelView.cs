using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IEmployeeLevelView
    {
        int LevelId { get; set; }
        string LevelName { get; set; }
        string LevelCode { get; set; }
        EmployeeLevelModel SelectedLevel { get; set; }
        IList<EmployeeLevelModel> Levels { set; }
        EmployeeLevelPresenter Presenter { set; }
    }
}
