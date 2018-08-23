using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task<List<AttendanceModel>> GetAllAsync();
        Task<List<AttendanceModel>> GetActiveAsync();
        Task<List<AttendanceModel>> GetAbsentAsync();
        Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate);
        Task<int> CountActiveAsync(string date);
        Task<int> CountAbsentAsync(string date);
    }
}
