using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
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
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeStateService _employeeStateService;
        private readonly IEmployeeDetailService _employeeDetailService;
        private readonly IEmployeeImageService _employeeImageService;
        private readonly IShiftService _shiftService;
        private readonly IShiftCalendarService _shiftCalendarService;

        public DashboardViewModelService(
            IAttendanceService attendanceService,
            IEmployeeService employeeService,
            IEmployeeStateService employeeStateService,
            IEmployeeDetailService employeeDetailService,
            IEmployeeImageService employeeImageService,
            IShiftService shiftService,
            IShiftCalendarService shiftCalendarService)
        {
            _attendanceService = attendanceService;
            _employeeService = employeeService;
            _employeeStateService = employeeStateService;
            _employeeDetailService = employeeDetailService;
            _employeeImageService = employeeImageService;
            _shiftService = shiftService;
            _shiftCalendarService = shiftCalendarService;
        }

        public async Task<DashboardViewModel> GetDashboardResult(string date, int? shiftId)
        {
            var viewModel = new DashboardViewModel();
            var filter = new AttendanceFilter();

            var currentShuftId = 1;

            // get current shift
            var shiftCalendar = await _shiftCalendarService.GetByDateAsync(DateTime.Today);

            if (shiftCalendar != null)
            {
                currentShuftId = shiftCalendar.ShiftId;
            }

            filter.AttendanceDate = date;
            //filter.ShiftId = shiftId ?? currentShuftId;

            var totalEmployee = await _employeeService.CountTotalEmployeeAsync();

            var employeeActive = await _attendanceService.GetActiveAsync(filter);
            var employeeAbsent = await _attendanceService.GetAbsentAsync(filter);

            var employeeState = await _employeeStateService.GetAllAsync();

            var totalWork = employeeState.Where(x => x.ShiftId == 1 || x.ShiftId == currentShuftId);
            var totalAbsent = employeeAbsent.Where(x => x.ShiftId == 1 || x.ShiftId == currentShuftId);

            viewModel.AttendanceStatusDay = GetAttendanceStatusAsync(employeeState, employeeActive, 1);
            viewModel.AttendanceStatusCurrent = GetAttendanceStatusAsync(employeeState, employeeActive, currentShuftId);

            var shifts = await _shiftService.GetAllAsync();

            viewModel.CurrentShift = shifts.FirstOrDefault(x => x.ShiftId == currentShuftId).ShiftName;

            var attendanceShifts = await SumAttendanceByShift(employeeActive, shifts);

            // Summary attendance by percent
            var percentAbsent = Math.Round(((double)totalAbsent.Count() / (double)totalWork.Count()) * 100, 2);
            var percentActive = 100 - percentAbsent;

            var percentAttendance = new string[] { $"{percentActive}", $"{percentAbsent}" };
            var percentAttendanceValue = JsonConvert.SerializeObject(percentAttendance, Formatting.None);

            // Summary attendance by job function
            var attendanceByJob = SummamryByJobFunction(employeeState, employeeActive, currentShuftId);
            var attendanceByJobLabel = JsonConvert.SerializeObject(attendanceByJob.Select(x => x.FunctionName).ToList(), Formatting.None);
            var attendanceByJobActive = JsonConvert.SerializeObject(attendanceByJob.Select(x => x.ActivePerson).ToList(), Formatting.None);
            var attendanceByJobAbsent = JsonConvert.SerializeObject(attendanceByJob.Select(x => x.AbsentPerson).ToList(), Formatting.None);

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


            viewModel.CountTotalEmployee = totalEmployee;
            viewModel.CountActiveWork = employeeActive.Count;
            viewModel.CountAbsent = totalAbsent.Count();
            viewModel.PercentAbsent = $"{percentAbsent}%";
            viewModel.Attendances = totalAbsent;
            viewModel.AttendanceByShift = attendanceShifts;
            viewModel.DepartmentChartLabel = new HtmlString(departmentChartLabel);
            viewModel.DepartmentChartValue = new HtmlString(departmentChartValue);
            viewModel.SectiobChartLabel = new HtmlString(sectionChartLabel);
            viewModel.SectiobChartValue = new HtmlString(sectionChartValue);
            viewModel.AttendancePercentValue = new HtmlString(percentAttendanceValue);
            viewModel.AttendanceByJobLabel = new HtmlString(attendanceByJobLabel);
            viewModel.AttendanceByJobActive = new HtmlString(attendanceByJobActive);
            viewModel.AttendanceByJobAbsent = new HtmlString(attendanceByJobAbsent);
            viewModel.AttendanceLevelLabel = new HtmlString(attendanceLevelLabel);
            viewModel.AttendanceLevelValue = new HtmlString(attendanceLevelValue);
            viewModel.TransportChartLabel = new HtmlString(transportChartLabel);
            viewModel.TransportChartValue = new HtmlString(transportChartValue);
            viewModel.Shifts = await _employeeDetailService.GetShifts();

            return viewModel;
        }

        public async Task<List<AttendanceModel>> GetEmployeeLeave(string date)
        {
            var filter = new AttendanceFilter();
            filter.AttendanceDate = date;

            var currentShuftId = 1;

            // get current shift
            var shiftCalendar = await _shiftCalendarService.GetByDateAsync(DateTime.Today);

            if (shiftCalendar != null)
            {
                currentShuftId = shiftCalendar.ShiftId;
            }

            var employeeAbsent = await _attendanceService.GetAbsentAsync(filter);
            var totalAbsent = employeeAbsent.Where(x => x.ShiftId == 1 || x.ShiftId == currentShuftId);
            return totalAbsent.ToList();
        }

        private async Task<List<AttendanceShift>> SumAttendanceByShift(List<AttendanceModel> employeeActive, List<ShiftModel> shifts)
        {
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

            return attendanceShifts;
        }

        private List<AttendanceJob> SummamryByJobFunction(
            List<EmployeeStateModel> employeeStates,
            List<AttendanceModel> employeeActives,
            int shiftId)
        {
            var attendanceJobs = new List<AttendanceJob>();

            var resutls = employeeStates
                .Where(x => x.ShiftId == 1 || x.ShiftId == shiftId)
                .GroupBy(g => new { g.JobFunction.FunctionName })
                .Select(x => new
                {
                    FunctionName = x.Key.FunctionName,
                    TotalPerson = x.Select(e => e.EmployeeId).Count()
                }).ToList();


            foreach (var item in resutls)
            {
                var activePerson = employeeActives.Count(x => x.FunctionName == item.FunctionName);
                var absentPrtson = item.TotalPerson - activePerson;

                var attendanceJob = new AttendanceJob
                {
                    FunctionName = item.FunctionName,
                    TotalPerson = item.TotalPerson,
                    ActivePerson = activePerson,
                    AbsentPerson = absentPrtson
                };

                attendanceJobs.Add(attendanceJob);
            }

            return attendanceJobs;
        }

        public List<AttendanceStatus> GetAttendanceStatusAsync(
            List<EmployeeStateModel> employeeStates,
            List<AttendanceModel> employeeActives,
            int shiftId)
        {
            var attendancStatuses = new List<AttendanceStatus>();

            var resutls = employeeStates
                .Where(x => x.ShiftId == shiftId)
                .GroupBy(g => new { g.JobFunction.Section.Department.DepartmentName, g.JobFunction.Section.SectionName, g.Shift.ShiftName })
                .Select(x => new
                {
                    Department = x.Key.DepartmentName,
                    Section = x.Key.SectionName,
                    Shift = x.Key.ShiftName,
                    TotalPerson = x.Select(e => e.EmployeeId).Count()
                }).ToList();

            foreach (var item in resutls)
            {
                var activePerson = employeeActives.Count(x => x.DepartmentName == item.Department && x.SectionName == item.Section && x.ShiftName == item.Shift);
                var absentPrtson = item.TotalPerson - activePerson;
                var activePercent = Math.Round((activePerson / (decimal)item.TotalPerson) * 100, 0);

                var attendancStatus = new AttendanceStatus
                {
                    Department = item.Department,
                    Section = item.Section,
                    ShiftName = item.Shift,
                    TotalPerson = item.TotalPerson,
                    ActivePerson = activePerson,
                    AbsentPerson = absentPrtson,
                    ActivePercent = activePercent
                };

                attendancStatuses.Add(attendancStatus);
            }

            var results = attendancStatuses.OrderBy(x => x.Department).ThenBy(x => x.ShiftName).ToList();

            return results;
        }

    }
}
