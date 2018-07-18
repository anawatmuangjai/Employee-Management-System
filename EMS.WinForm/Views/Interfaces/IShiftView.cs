using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IShiftView
    {
        byte ShiftId { get; set; }
        string ShiftName { get; set; }
        TimeSpan StartTime { get; }
        TimeSpan EndTime { get; }
        ShiftModel SelectedShift { get; set; }
        IList<ShiftModel> Shifts { set; }
        ShiftPresenter Presenter { set; }
    }
}
