using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task<List<AttendanceModel>> GetActiveAsync(AttendanceFilter filter);
        Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter);
        Task<List<AttendanceModel>> GetHistoryAsync(AttendanceFilter filter);
    }
}
