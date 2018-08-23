using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
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

        public AttendanceService(IAsyncRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<AttendanceModel>> GetActiveAsync()
        {
            var employee = await _employeeRepository.GetAllAsync();

            return employee.Select(x => new AttendanceModel
            {
                EmployeeId = x.EmployeeId,
                Title = x.Title,
                EmployeeType = x.EmployeeType,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FirstNameThai = x.FirstNameThai,
                LastNameThai = x.LastNameThai,
                LevelCode = "SP1",
                ShiftName = "A",
                DepartmentCode = "AM",
                SectionCode = "Test",
                JobTitle = "Engineer",
                FunctionName = "System Engineer",
                BusStationName = "X14",
                ScanInTime = "2018/08/01 08:00:00",
                ScanOutTime = "2018/08/01 08:00:00",
            }).ToList();
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync()
        {
            var employee = await _employeeRepository.GetAllAsync();

            return employee.Select(x => new AttendanceModel
            {
                EmployeeId = x.EmployeeId,
                Title = x.Title,
                EmployeeType = x.EmployeeType,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FirstNameThai = x.FirstNameThai,
                LastNameThai = x.LastNameThai,
                LevelCode = "SP1",
                ShiftName = "A",
                DepartmentCode = "AM",
                SectionCode = "Test",
                JobTitle = "Engineer",
                FunctionName = "System Engineer",
                BusStationName = "X14",
                ScanInTime = "2018/08/01 08:00:00",
                ScanOutTime = "2018/08/01 08:00:00",
            }).Take(15).ToList();
        }

        public async Task<List<AttendanceModel>> GetAllAsync()
        {
            var employee = await _employeeRepository.GetAllAsync();

            var attendances = employee.Select(x => new AttendanceModel
            {
                EmployeeId = x.EmployeeId,
                Title = x.Title,
                EmployeeType = x.EmployeeType,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FirstNameThai = x.FirstNameThai,
                LastNameThai = x.LastNameThai,
                LevelCode = "SP1",
                ShiftName = "A",
                DepartmentCode = "AM",
                SectionCode = "Test",
                JobTitle = "Engineer",
                FunctionName = "System Engineer",
                BusStationName = "X14",
                ScanInTime = "2018/08/01 08:00:00",
                ScanOutTime = "2018/08/01 08:00:00",
            }).ToList();

            return attendances;
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate)
        {
            var employee = await _employeeRepository.GetAllAsync();

            return employee.Select(x => new AttendanceModel
            {
                EmployeeId = x.EmployeeId,
                Title = x.Title,
                EmployeeType = x.EmployeeType,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FirstNameThai = x.FirstNameThai,
                LastNameThai = x.LastNameThai,
                LevelCode = "SP1",
                ShiftName = "A",
                DepartmentCode = "AM",
                SectionCode = "Test",
                JobTitle = "Engineer",
                FunctionName = "System Engineer",
                BusStationName = "X14",
                ScanInTime = "2018/08/01 08:00:00",
                ScanOutTime = "2018/08/01 08:00:00",
            }).Take(15).ToList();
        }

        public async Task<int> CountActiveAsync(string date)
        {
            return 340;
        }

        public async Task<int> CountAbsentAsync(string date)
        {
            return 20;
        }
    }
}
