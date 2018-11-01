using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IDashboardViewModelService
    {
        Task<DashboardViewModel> GetDashboardResult(string date, int? shiftId);
        Task<List<AttendanceModel>> GetEmployeeLeave(string date);
    }
}
