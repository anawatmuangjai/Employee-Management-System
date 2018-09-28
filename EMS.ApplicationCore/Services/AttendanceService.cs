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
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAttendanceRepository _attenRepository;

        public AttendanceService(
            IAsyncRepository<Employee> employeeRepository,
            IAttendanceRepository attenRepository)
        {
            _employeeRepository = employeeRepository;
            _attenRepository = attenRepository;
        }

        public async Task<List<AttendanceModel>> GetActiveAsync(string date)
        {
            return await _attenRepository.GetActiveAsync(date);
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync(string date)
        {
            return await _attenRepository.GetAbsentAsync(date);
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate)
        {
            return await _attenRepository.GetHistoryAsync(employeeId, startDate, endDate);
        }

        public async Task<int> CountTotalEmployeeAsync()
        {
            return await _employeeRepository.CountAsync(x => x.AvailableFlag == true);
        }
    }
}
