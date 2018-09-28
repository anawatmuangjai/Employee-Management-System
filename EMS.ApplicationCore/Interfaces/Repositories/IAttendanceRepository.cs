using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceModel>> GetActiveAsync(string date);
        Task<List<AttendanceModel>> GetAbsentAsync(string date);
        Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate);
    }
}
