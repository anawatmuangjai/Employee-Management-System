using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class EmployeeViewModelService : IEmployeeViewModelService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeDetailService _employeeDetailService;

        public EmployeeViewModelService(
            IEmployeeService employeeService,
            IEmployeeDetailService employeeDetailService)
        {
            _employeeService = employeeService;
            _employeeDetailService = employeeDetailService;
        }

        public async Task CreateAsync(RegisterEmployeeViewModel viewModel)
        {
            var employee = new EmployeeModel
            {
                EmployeeId = viewModel.EmployeeId,
                GlobalId = viewModel.GlobalId,
                CardId = viewModel.CardId,
                EmployeeType = viewModel.EmployeeType,
                Title = viewModel.Title,
                TitleThai = viewModel.TitleThai,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                FirstNameThai = viewModel.FirstNameThai,
                LastNameThai = viewModel.LastNameThai,
                Gender = viewModel.Gender,
                Height = viewModel.Height,
                Hand = viewModel.Hand,
                BirthDate = viewModel.BirthDate,
                HireType = viewModel.HireType,
                HireDate = viewModel.HireDate,
                AvailableFlag = true,
                ChangedDate = DateTime.Now,
            };

            await _employeeService.AddAsync(employee);
        }

        public async Task<EmployeeViewModel> GetEmployeeList()
        {
            var employee = await _employeeService.GetAllAsync();

            var viewModel = new EmployeeViewModel
            {
                Employees = employee
            };

            return viewModel;
        }

        public async Task<EmployeeViewModel> GetEmployeeList(string employeeId)
        {
            var employee = await _employeeService.GetByEmployeeIdAsync(employeeId);

            var viewModel = new EmployeeViewModel
            {
                Employees = new List<EmployeeModel>() { employee }
            };

            return viewModel;
        }

        public async Task<EmployeeViewModel> GetEmployeeList(EmployeeFilter filter)
        {
            var viewModel = new EmployeeViewModel();

            var employees = await _employeeService.GetAsync(filter);

            if (employees != null)
            {
                viewModel.Employees = employees;
                viewModel.Departments = await _employeeDetailService.GetDepartments();
                viewModel.Shifts = await _employeeDetailService.GetShifts();
                viewModel.Positions = await _employeeDetailService.GetPositions();
            }

            return viewModel;
        }
    }
}
