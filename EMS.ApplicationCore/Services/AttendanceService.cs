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
            var spec = new EmployeeSpecification(x => x.AvailableFlag == true);
            var employees = await _employeeRepository.GetAsync(spec);
            var attendances = await _attendanceRepository.GetAsync(x => x.PassCode == "I" && x.PassTime.Contains(today));

            var attendanceResult = (from e in employees
                                    join a in attendances on e.EmployeeId equals a.EmployeeId
                                    select new AttendanceModel
                                    {
                                        AttendanceDate = today,
                                        EmployeeId = e.EmployeeId,
                                        Title = e.Title,
                                        EmployeeType = e.EmployeeType,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        FirstNameThai = e.FirstNameThai,
                                        LastNameThai = e.LastNameThai,
                                        LevelCode = e.EmployeeState?.Level.LevelCode ?? "-",
                                        ShiftName = e.EmployeeState?.Shift.ShiftName ?? "-",
                                        DepartmentCode = e.EmployeeState?.JobFunction.Section.Department.DepartmentCode ?? "-",
                                        SectionCode = e.EmployeeState?.JobFunction.Section.SectionCode ?? "-",
                                        JobTitle = e.EmployeeState?.Position.PositionName ?? "-",
                                        FunctionName = e.EmployeeState?.JobFunction.FunctionName ?? "-",
                                        BusStationName = e.EmployeeState?.BusStation.BusStationName ?? "-",
                                        PassCode = a.PassCode,
                                        ScanInTime = a?.PassTime ?? "-",
                                        ScanOutTime = "-",
                                    }).ToList();

            return attendanceResult;
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync()
        {
            var today = DateTime.Today.ToString("yyyy/MM/dd");
            var spec = new EmployeeSpecification(x => x.AvailableFlag == true);
            var employees = await _employeeRepository.GetAsync(spec);
            var attendances = await _attendanceRepository.GetAsync(x => x.PassCode == "I" && x.PassTime.Contains(today));

            var query = (from e in employees
                         join a in attendances on e.EmployeeId equals a.EmployeeId into g
                         from s in g.DefaultIfEmpty()
                         select new
                         {
                             e.EmployeeId,
                             e.Title,
                             e.EmployeeType,
                             e.FirstName,
                             e.LastName,
                             e.FirstNameThai,
                             e.LastNameThai,
                             LevelCode = e.EmployeeState?.Level.LevelCode ?? "-",
                             ShiftName = e.EmployeeState?.Shift.ShiftName ?? "-",
                             DepartmentCode = e.EmployeeState?.JobFunction.Section.Department.DepartmentCode ?? "-",
                             SectionCode = e.EmployeeState?.JobFunction.Section.SectionCode ?? "-",
                             PositionName = e.EmployeeState?.Position.PositionName ?? "-",
                             FunctionName = e.EmployeeState?.JobFunction.FunctionName ?? "-",
                             BusStationName = e.EmployeeState?.BusStation.BusStationName ?? "-",
                             PassTime = s?.PassTime ?? "-"
                         }).ToList();

            var attendanceResult = query
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
                    LevelCode = x.LevelCode,
                    ShiftName = x.ShiftName,
                    DepartmentCode = x.DepartmentCode,
                    SectionCode = x.SectionCode,
                    JobTitle = x.PositionName,
                    FunctionName = x.FunctionName,
                    BusStationName = x.BusStationName,
                    ScanInTime = "-",
                    ScanOutTime = "-",
                }).ToList();

            return attendanceResult;
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate)
        {
            var today = DateTime.Today.ToString("yyyy/MM/dd");
            var spec = new EmployeeSpecification(x => x.AvailableFlag == true && x.EmployeeId == employeeId);
            var employees = await _employeeRepository.GetAsync(spec);
            var attendances = await _attendanceRepository.GetAsync(x => x.EmployeeId == employeeId);

            var attendanceByDate = attendances
                                    .Select(x => new
                                    {
                                        AttendanceDate = x.PassTime.Substring(0, 10),
                                        x.EmployeeId,
                                        x.PassCode,
                                        x.PassTime
                                    }).ToList();

            var attendanceResult = (from a in attendanceByDate
                                    group a by new { a.EmployeeId, a.AttendanceDate } into g
                                    select new
                                    {
                                        g.Key.AttendanceDate,
                                        g.Key.EmployeeId,
                                        ScanInTime = g.Where(x => x.PassCode == "I").Min(x => x.PassTime) ?? "-",
                                        ScanOutTime = g.Where(x => x.PassCode == "O").Max(x => x.PassTime) ?? "-",
                                    }).ToList();

            var attendanceModels = (from e in employees
                                    join a in attendanceResult on e.EmployeeId equals a.EmployeeId
                                    select new AttendanceModel
                                    {
                                        AttendanceDate = a.AttendanceDate,
                                        EmployeeId = e.EmployeeId,
                                        Title = e.Title,
                                        EmployeeType = e.EmployeeType,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        FirstNameThai = e.FirstNameThai,
                                        LastNameThai = e.LastNameThai,
                                        LevelCode = e.EmployeeState.Level.LevelCode,
                                        ShiftName = e.EmployeeState.Shift.ShiftName,
                                        DepartmentCode = e.EmployeeState.JobFunction.Section.Department.DepartmentCode,
                                        SectionCode = e.EmployeeState.JobFunction.Section.SectionCode,
                                        JobTitle = e.EmployeeState.Position.PositionName,
                                        FunctionName = e.EmployeeState.JobFunction.FunctionName,
                                        BusStationName = e.EmployeeState.BusStation.BusStationName,
                                        ScanInTime = a.ScanInTime,
                                        ScanOutTime = a.ScanOutTime
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
