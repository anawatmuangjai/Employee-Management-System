using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using EMS.WebCore.Models.Dashboard;
using EMS.WebCore.ViewModels.Dashboard;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class DashboardViewModelService : IDashboardViewModelService
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IEmployeeStateService _employeeStateService;
        private readonly IShiftService _shiftService;

        public DashboardViewModelService(
            IAttendanceService attendanceService,
            IEmployeeStateService employeeStateService,
            IShiftService shiftService)
        {
            _attendanceService = attendanceService;
            _employeeStateService = employeeStateService;
            _shiftService = shiftService;
        }

        public async Task<DashboardViewModel> GetDashboardResult(string date)
        {
            var totalEmployee = await _attendanceService.CountTotalEmployeeAsync();

            var employeeActive = await _attendanceService.GetActiveAsync(date);
            var employeeAbsent = await _attendanceService.GetAbsentAsync(date);

            // todo get current shift by time start and time end
            //var currentTime = DateTime.Now.TimeOfDay;
            //var shifts = await _shiftService.GetByTimeAsync(currentTime);
            var shifts = await _shiftService.GetAllAsync();

            var attendanceShifts = new List<AttendanceShift>();

            foreach (var s in shifts)
            {
                var employeePerShift = await _employeeStateService.CountShiftAsync(s.ShiftId);
                var employeeActivePerShift = employeeActive.Count(x => x.ShiftName == s.ShiftName);

                var attendanceShift = new AttendanceShift
                {
                    ShiftName = s.ShiftName,
                    TotalEmployee = employeePerShift,
                    ActiveEmployee = employeeActivePerShift
                };

                attendanceShifts.Add(attendanceShift);
            }

            // Summary attendance by percent
            var percentAbsent = Math.Round(((double)employeeAbsent.Count / (double)totalEmployee) * 100, 2);
            var percentActive = 100 - percentAbsent;

            var percentAttendance = new string[] { $"{percentActive}", $"{percentAbsent}" };
            var percentAttendanceValue = JsonConvert.SerializeObject(percentAttendance, Formatting.None);

            // Summary attendance by level
            var attendanceByLevel = employeeActive
                .OrderBy(x => x.LevelCode)
                .GroupBy(g => g.LevelCode)
                .Select(x => new
                {
                    Level = x.Key,
                    Quantity = x.Select(e => e.EmployeeId).Count()
                });

            var attendanceLevelLabel = JsonConvert.SerializeObject(attendanceByLevel.Select(x => x.Level).ToList(), Formatting.None);
            var attendanceLevelValue = JsonConvert.SerializeObject(attendanceByLevel.Select(x => x.Quantity).ToList(), Formatting.None);

            // Summary attendance by department
            var attendanceByDepartment = employeeActive
                .GroupBy(g => g.DepartmentCode)
                .Select(x => new
                {
                    Department = x.Key,
                    Quantity = x.Select(e => e.EmployeeId).Count()
                }).ToList();

            var departmentChartLabel = JsonConvert.SerializeObject(attendanceByDepartment.Select(x => x.Department).ToList(), Formatting.None);
            var departmentChartValue = JsonConvert.SerializeObject(attendanceByDepartment.Select(x => x.Quantity).ToList(), Formatting.None);

            // Summary attendance by section
            var attendanceSections = employeeActive
                .GroupBy(g => g.SectionName)
                .Select(x => new
                {
                    SectionName = x.Key,
                    Quantity = x.Select(e => e.EmployeeId).Count()
                });

            var sectionChartLabel = JsonConvert.SerializeObject(attendanceSections.Select(x => x.SectionName).ToList(), Formatting.None);
            var sectionChartValue = JsonConvert.SerializeObject(attendanceSections.Select(x => x.Quantity).ToList(), Formatting.None);

            // Summary transportation by route
            var transportRoutes = employeeActive
                .GroupBy(g => g.RouteName)
                .Select(x => new
                {
                    RouteName = x.Key,
                    Quantity = x.Select(e => e.EmployeeId).Count()
                });

            var transportChartLabel = JsonConvert.SerializeObject(transportRoutes.Select(x => x.RouteName).ToList(), Formatting.None);
            var transportChartValue = JsonConvert.SerializeObject(transportRoutes.Select(x => x.Quantity).ToList(), Formatting.None);

            var viewModel = new DashboardViewModel
            {
                CountTotalEmployee = totalEmployee,
                CountActiveWork = employeeActive.Count,
                CountAbsent = employeeAbsent.Count,
                PercentAbsent = $"{percentAbsent}%",
                Attendances = employeeAbsent,
                AttendanceByShift = attendanceShifts,
                DepartmentChartLabel = new HtmlString(departmentChartLabel),
                DepartmentChartValue = new HtmlString(departmentChartValue),
                SectiobChartLabel = new HtmlString(sectionChartLabel),
                SectiobChartValue = new HtmlString(sectionChartValue),
                AttendancePercentValue = new HtmlString(percentAttendanceValue),
                AttendanceLevelLabel = new HtmlString(attendanceLevelLabel),
                AttendanceLevelValue = new HtmlString(attendanceLevelValue),
                TransportChartLabel = new HtmlString(transportChartLabel),
                TransportChartValue = new HtmlString(transportChartValue),
            };

            return viewModel;
        }
    }
}
