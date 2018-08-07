using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IEmployeeView _view;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeAddressService _employeeDetailService;
        private readonly IEmployeeStateService _employeeStateService;
        private readonly IEmployeePasswordService _employeePasswordService;
        private readonly IEmployeeImageService _employeeImageService;
        private readonly IEmployeeLevelService _employeeLevelService;
        private readonly IBusStationService _busStationService;
        private readonly IDepartmentService _departmentService;
        private readonly ISectionService _sectionService;
        private readonly IShiftService _shiftService;
        private readonly IJobService _jobService;

        public EmployeePresenter(
            IEmployeeView view,
            IEmployeeService employeeService,
            IEmployeeAddressService employeeDetailService,
            IEmployeeStateService employeeStateService,
            IEmployeePasswordService employeePasswordService,
            IEmployeeImageService employeeImageService,
            IEmployeeLevelService employeeLevelService,
            IBusStationService busStationService,
            IDepartmentService departmentService,
            ISectionService sectionService,
            IShiftService shiftService,
            IJobService jobService)
        {
            _view = view;
            _view.Presenter = this;
            _employeeService = employeeService;
            _employeeDetailService = employeeDetailService;
            _employeeStateService = employeeStateService;
            _employeePasswordService = employeePasswordService;
            _employeeImageService = employeeImageService;
            _employeeLevelService = employeeLevelService;
            _busStationService = busStationService;
            _departmentService = departmentService;
            _sectionService = sectionService;
            _shiftService = shiftService;
            _jobService = jobService;
        }

        public IEmployeeView GetView()
        {
            return _view;
        }

        public async Task GetEmployeeLevelsAsync()
        {
            _view.Levels = await _employeeLevelService.GetAllAsync();
        }

        public async Task GetDepartmentsAsync()
        {
            _view.Departments = await _departmentService.GetAllAsync();
        }

        public async Task GetSectionsAsync()
        {
            _view.Sections = await _sectionService.GetAllAsync();
        }

        public async Task GetShiftsAsync()
        {
            _view.Shifts = await _shiftService.GetAllAsync();
        }

        public async Task GetJobsAsync()
        {
            _view.Jobs = await _jobService.GetAllAsync();
        }

        public async Task GetBusStationAsync()
        {
            _view.BusStations = await _busStationService.GetAllAsync();
        }

        public async Task SaveAsync()
        {
            var employee = new EmployeeModel
            {
                EmployeeId = _view.EmployeeId,
                GlobalId = _view.GlobalId,
                CardId = _view.CardId,
                EmployeeType = _view.EmployeeType,
                Title = _view.Title,
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                FirstNameThai = _view.FirstNameThai,
                LastNameThai = _view.LastNameThai,
                Gender = _view.Gender,
                BirthDate = _view.BirthDate,
                HireDate = _view.HireDate,
                AvailableFlag = true,
                ChangedDate = _view.ChangedDate,
            };

            employee = await _employeeService.AddAsync(employee);

            if (employee == null)
                return;

            var employeePassword = new EmployeePasswordModel
            {
                EmployeeId = employee.EmployeeId,
                ChangedDate = _view.ChangedDate,
                //PasswordHash = "HashTest",
                //PasswordSalt = "SaltTest",
            };

            employeePassword = await _employeePasswordService.AddAsync(employeePassword);

            var employeeDetail = new EmployeeAddressModel
            {
                EmployeeId = employee.EmployeeId,
                HomeAddress = _view.Address,
                City = _view.City,
                Country = _view.Country,
                PostalCode = _view.PostalCode,
                PhoneNumber = _view.PhoneNumber,
                EmailAddress = _view.EmailAddress,
                ChangedDate = _view.ChangedDate,
            };

            employeeDetail = await _employeeDetailService.AddAsync(employeeDetail);

            var employeeState = new EmployeeStateModel
            {
                EmployeeId = employee.EmployeeId,
                SectionId = _view.SectionId,
                ShiftId = _view.ShiftId,
                JobTitleId = _view.JobId,
                LevelId = _view.LevelId,
                BusStationId = _view.BusStationId,
                JoinDate = _view.JoinDate,
                ChangedDate = _view.ChangedDate,
            };

            employeeState = await _employeeStateService.AddAsync(employeeState);

            var employeeImage = new EmployeeImageModel
            {
                EmployeeId = employee.EmployeeId,
                Images = _view.EmployeeImage
            };

            employeeImage = await _employeeImageService.AddAsync(employeeImage);

        }
    }
}
