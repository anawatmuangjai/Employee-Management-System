using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using EMS.WebCore.Models;
using EMS.WebCore.ViewModels.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class AttendanceViewModelService : IAttendanceViewModelService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeImageService _employeeImageService;
        private readonly IAttendanceService _attendanceService;
        private readonly IEmployeeDetailService _employeeDetailService;

        public AttendanceViewModelService(
            IEmployeeService employeeService,
            IEmployeeImageService employeeImageService,
            IAttendanceService attendanceService,
            IEmployeeDetailService employeeDetailService)
        {
            _employeeService = employeeService;
            _employeeImageService = employeeImageService;
            _attendanceService = attendanceService;
            _employeeDetailService = employeeDetailService;
        }

        public async Task<AttendanceViewModel> GetActive(string date)
        {
            var viewModel = new AttendanceViewModel();

            var attendances = await _attendanceService.GetActiveAsync(date);

            viewModel.Attendances = attendances;
            viewModel.FilterModel = await GetAttendanceFilterAsync();

            return viewModel;
        }

        public async Task<AttendanceViewModel> GetActive(AttendanceFilterModel filter)
        {
            var date = DateTime.Today.ToString("yyyy/MM/dd");

            var viewModel = new AttendanceViewModel();

            var attendances = await _attendanceService.GetActiveAsync(date);

            viewModel.Attendances = attendances;
            viewModel.FilterModel = await GetAttendanceFilterAsync();

            return viewModel;
        }

        public async Task<AttendanceViewModel> GetAbsent(string date)
        {
            var viewModel = new AttendanceViewModel();

            var attendances = await _attendanceService.GetAbsentAsync(date);

            viewModel.Attendances = attendances;
            viewModel.FilterModel = await GetAttendanceFilterAsync();

            return viewModel;
        }

        public async Task<AttendanceFilterModel> GetAttendanceFilterAsync()
        {
            var shifts = await _employeeDetailService.GetShifts();
            var positions = await _employeeDetailService.GetPositions();
            var jobFunctions = await _employeeDetailService.GetJobFunctions();
            var departments = await _employeeDetailService.GetDepartments();
            var sections = await _employeeDetailService.GetSections();

            var filterModel = new AttendanceFilterModel
            {
                Shifts = shifts,
                Positions = positions,
                JobFunctions = jobFunctions,
                Departments = departments,
                Sections = sections
            };

            return filterModel;
        }
    }
}
