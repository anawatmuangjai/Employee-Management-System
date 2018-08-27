using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class ProfileViewModelService : IProfileViewModelService
    {
        private readonly IEmployeeDetailService _employeeDetailService;
        private readonly IEmployeeStateService _employeeStateService;
        private readonly IEmployeeService _employeeService;

        public ProfileViewModelService(
            IEmployeeDetailService employeeDetailService,
            IEmployeeStateService employeeStateService,
            IEmployeeService employeeService)
        {
            _employeeDetailService = employeeDetailService;
            _employeeStateService = employeeStateService;
            _employeeService = employeeService;
        }

        public async Task<ProfileEditViewModel> EditProfile(string employeeId)
        {
            var employee = await _employeeService.GetByEmployeeIdAsync(employeeId);

            var viewModel = new ProfileEditViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Departments = await _employeeDetailService.GetDepartments(),
                Sections = await _employeeDetailService.GetSections(),
                Shifts = await _employeeDetailService.GetShifts(),
                JobTitles = await _employeeDetailService.GetJobTitles(),
                JobFunctions = await _employeeDetailService.GetJobFunctions(),
                JobLevels = await _employeeDetailService.GetLevels(),
                BusStations = await _employeeDetailService.GetBusStations()
            };

            return viewModel;
        }

        public async Task UpdateProfile(ProfileEditViewModel model)
        {
            var employeeState = new EmployeeStateModel
            {
                EmployeeId = model.EmployeeId,
                SectionId = model.SectionId,
                ShiftId = (byte)model.ShiftId,
                JobTitleId = model.JobTitleId,
                LevelId = model.LevelId,
                BusStationId = model.BusStationId,
                JoinDate = model.JoinDate,
                ChangedDate = DateTime.Now
            };

            var exist = await _employeeStateService.ExistsAsync(model.EmployeeId);

            if (exist)
            {
                await _employeeStateService.UpdateAsync(employeeState);
            }
            else
            {
                await _employeeStateService.AddAsync(employeeState);
            }
        }
    }
}
