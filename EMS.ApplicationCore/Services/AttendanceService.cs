using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Specifications;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attenRepository;

        public AttendanceService(IAttendanceRepository attenRepository)
        {
            _attenRepository = attenRepository;
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate)
        {
            return await _attenRepository.GetHistoryAsync(employeeId, startDate, endDate);
        }

        public async Task<List<AttendanceModel>> GetActiveAsync(AttendanceFilter filter)
        {
            return await _attenRepository.GetActiveAsync(filter);
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter)
        {
            return await _attenRepository.GetAbsentAsync(filter);
        }
    }
}
