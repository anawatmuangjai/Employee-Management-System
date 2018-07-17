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
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        ShiftPresenter Presenter { set; }
    }
}
