using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceModel>> GetActiveAsync(AttendanceFilter filter);
        Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter);
        Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate);
    }
}
