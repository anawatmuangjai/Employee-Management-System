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
        private readonly IEmployeeDetailService _employeeDetailService;
        private readonly IEmployeeLevelService _employeeLevelService;
        private readonly IDepartmentService _departmentService;
        private readonly ISectionService _sectionService;
        private readonly IShiftService _shiftService;
        private readonly IJobService _jobService;

        public EmployeePresenter(
            IEmployeeView view,
            IEmployeeService employeeService,
            IEmployeeDetailService employeeDetailService,
            IEmployeeLevelService employeeLevelService,
            IDepartmentService departmentService,
            ISectionService sectionService,
            IShiftService shiftService,
            IJobService jobService)
        {
            _view = view;
            _view.Presenter = this;
            _employeeService = employeeService;
            _employeeDetailService = employeeDetailService;
            _employeeLevelService = employeeLevelService;
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

        public async Task SaveAsync()
        {
            var employee = new EmployeeModel
            {
                GlobalId = _view.GlobalId,
                CardId = _view.CardId,
                EmployeeType = _view.EmployeeType,
                Title = _view.Title,
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                FirstNameThai = _view.FirstNameThai,
                LastNameThai = _view.LastNameThai,
                Gender = _view.Gender,
                AvailableFlag = _view.AvailableFlag,
                HireDate = _view.HireDate,
                ChangedDate = _view.ChangedDate,
            };

            employee = await _employeeService.AddAsync(employee);

            if (employee.EmployeeId == 0)
                return;

            var employeeDetail = new EmployeeDetailModel
            {
                EmployeeId = employee.EmployeeId,
                Address = _view.Address,
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
                DepartmentId = _view.DepartmentId,
                ShiftId = _view.ShiftId,
                JobId = _view.JobId,
                LevelId = _view.LevelId,
                JoinDate = _view.JoinDate,
                ChangedDate = _view.ChangedDate,
            };

        }
    }
}
