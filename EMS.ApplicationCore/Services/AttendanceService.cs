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
        private readonly IAsyncRepository<Attendance> _attendanceRepository;

        public AttendanceService(
            IAsyncRepository<Employee> employeeRepository,
            IAsyncRepository<Attendance> attendanceRepository)
        {
            _employeeRepository = employeeRepository;
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<AttendanceModel>> GetActiveAsync()
        {
            var today = DateTime.Today.ToString("yyyy/MM/dd");

            var spec = new AttendanceSpecification(x => x.PassCode == "I" && x.PassTime.Contains(today));

            var attendances = await _attendanceRepository.GetAsync(spec);

            return attendances.Select(x => new AttendanceModel
            {
                EmployeeId = x.EmployeeId,
                Title = x.Employee.Title,
                EmployeeType = x.Employee.EmployeeType,
                FirstName = x.Employee.FirstName,
                LastName = x.Employee.LastName,
                FirstNameThai = x.Employee.FirstNameThai,
                LastNameThai = x.Employee.LastNameThai,
                LevelCode = x.Employee.EmployeeState.Level.LevelCode,
                ShiftName = x.Employee.EmployeeState.Shift.ShiftName,
                DepartmentCode = x.Employee.EmployeeState.Department.DepartmentCode,
                SectionCode = x.Employee.EmployeeState.Section.SectionName,
                JobTitle = x.Employee.EmployeeState.Position.PositionName,
                FunctionName = x.Employee.EmployeeState.JobFunction.FunctionName,
                BusStationName = x.Employee.EmployeeState.BusStation.BusStationName,
                PassCode = "In",
                ScanInTime = x.PassTime,
                ScanOutTime = "-",
            }).ToList();
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync()
        {
            var today = DateTime.Today.ToString("yyyy/MM/dd");

            var employees = await _employeeRepository.GetAsync(x => x.AvailableFlag == true);
            var attendances = await _attendanceRepository.GetAsync(x => x.PassTime.Contains(today) && x.PassCode == "I");

            var query = (from e in employees
                         join a in attendances on e.EmployeeId equals a.EmployeeId into g
                         from s in g.DefaultIfEmpty()
                         select new
                         {
                             EmployeeId = e.EmployeeId,
                             Title = e.Title,
                             EmployeeType = e.EmployeeType,
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             FirstNameThai = e.FirstNameThai,
                             LastNameThai = e.LastNameThai,
                             LevelCode = "SP1",
                             ShiftName = "A",
                             DepartmentCode = "AM",
                             SectionCode = "Test",
                             JobTitle = "Engineer",
                             FunctionName = "System Engineer",
                             BusStationName = "X14",
                             PassTime = s?.PassTime ?? "-"
                         }).ToList();

            var attendanceModels = query
                .Where(x => x.PassTime == "-")
                .Select(x => new AttendanceModel
                {
                    AttendanceDate = today,
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
                    ScanInTime = "-",
                    ScanOutTime = "-",
                }).ToList();

            return attendanceModels;
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate)
        {
            var today = DateTime.Today.ToString("yyyy/MM/dd");
            var spec = new AttendanceSpecification(x => x.Employee.AvailableFlag == true && x.EmployeeId == employeeId);
            var attendances = await _attendanceRepository.GetAsync(spec);

            var result = attendances
                .Select(x => new
                {
                    AttendanceDate = x.PassTime.Substring(0, 10),
                    x.EmployeeId,
                    x.Employee.Title,
                    x.Employee.EmployeeType,
                    x.Employee.FirstName,
                    x.Employee.LastName,
                    x.Employee.FirstNameThai,
                    x.Employee.LastNameThai,
                    LevelCode = "SP1",
                    ShiftName = "A",
                    DepartmentCode = "AM",
                    SectionCode = "Test",
                    JobTitle = "Engineer",
                    FunctionName = "Developer",
                    BusStationName = "X14",
                    x.PassCode,
                    x.PassTime,
                }).ToList();

            var attendanceModels = (from e in result
                                    group e by new { e.EmployeeId, e.AttendanceDate } into g
                                    select new AttendanceModel
                                    {
                                        AttendanceDate = g.Key.AttendanceDate,
                                        EmployeeId = g.Key.EmployeeId,
                                        Title = g.First().Title,
                                        EmployeeType = g.First().EmployeeType,
                                        FirstName = g.First().FirstName,
                                        LastName = g.First().LastName,
                                        FirstNameThai = g.First().FirstNameThai,
                                        LastNameThai = g.First().LastNameThai,
                                        LevelCode = "SP1",
                                        ShiftName = "A",
                                        DepartmentCode = "AM",
                                        SectionCode = "Test",
                                        JobTitle = "Engineer",
                                        FunctionName = "Developer",
                                        BusStationName = "X14",
                                        ScanInTime = g.Where(x => x.PassCode == "I").Min(x => x.PassTime) ?? "-",
                                        ScanOutTime = g.Where(x => x.PassCode == "O").Max(x => x.PassTime) ?? "-"
                                    }).ToList();

            return attendanceModels;
        }

        public async Task<int> CountActiveAsync(string date)
        {
            return await _attendanceRepository.CountAsync(x => x.PassTime.Contains(date) && x.PassCode == "I");
        }

        public async Task<int> CountAbsentAsync(string date)
        {
            var totalEmployee = await _employeeRepository.CountAsync(x => x.AvailableFlag == true);
            var attedance = await _attendanceRepository.CountAsync(x => x.PassTime.Contains(date) && x.PassCode == "I");
            return totalEmployee - attedance;
        }

        public async Task<int> CountTotalEmployeeAsync()
        {
            return await _employeeRepository.CountAsync(x => x.AvailableFlag == true);
        }
    }
}
