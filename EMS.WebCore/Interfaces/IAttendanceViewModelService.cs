using EMS.ApplicationCore.Helper;
using EMS.WebCore.Models;
using EMS.WebCore.ViewModels.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IAttendanceViewModelService
    {
        Task<AttendanceViewModel> GetActive(AttendanceFilter filter);
        Task<AttendanceViewModel> GetActive(string date);
        Task<AttendanceViewModel> GetAbsent(string date);
    }
}
