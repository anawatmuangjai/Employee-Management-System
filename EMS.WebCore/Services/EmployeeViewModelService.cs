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

        public EmployeeViewModelService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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

        public async Task<EmployeeProfileViewModel> GetEmployeeProfile(string employeeId)
        {
            var employee = await _employeeService.GetByEmployeeIdAsync(employeeId);

            var viewModel = new EmployeeProfileViewModel
            {
                EmployeeId = employee.EmployeeId,
                GlobalId = employee.GlobalId,
                CardId = employee.CardId,
                EmployeeType = employee.EmployeeType,
                Title = employee.Title,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                FirstNameThai = employee.FirstNameThai,
                LastNameThai = employee.LastNameThai,
                Gender = employee.Gender,
                Age = CalculateAge(employee.BirthDate),
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                EmploymentDuration = CalculateDurationOfEmployment(employee.HireDate)
            };

            return viewModel;
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        private int CalculateDurationOfEmployment(DateTime hierDate)
        {
            var today = DateTime.Today;
            var duration = today.Year - hierDate.Year;
            if (hierDate > today.AddYears(-duration)) duration--;
            return duration;
        }
    }
}
