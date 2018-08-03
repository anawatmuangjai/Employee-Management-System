using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class EmployeeRegisterService : IEmployeeRegisterService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly ISectionService _sectionService;
        private readonly IJobService _jobService;
        private readonly IEmployeeLevelService _levelService;
        private readonly IShiftService _shiftService;

        public EmployeeRegisterService(IEmployeeService employeeService,
            IDepartmentService departmentService,
            ISectionService sectionService,
            IJobService jobService,
            IEmployeeLevelService levelService,
            IShiftService shiftService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _sectionService = sectionService;
            _jobService = jobService;
            _levelService = levelService;
            _shiftService = shiftService;
        }

        public async Task<RegisterEmployeeViewModel> GetRegisterEmployeeViewModel()
        {
            var viewModel = new RegisterEmployeeViewModel
            {
                Departments = await GetDepartments(),
                Sections = await GetSections(),
                JobTitles = await GetJobTitles(),
                Levels = await GetLevels(),
                Shifts = await GetShifts()
            };

            return viewModel;
        }

        public async Task CreateEmployee(RegisterEmployeeViewModel viewModel)
        {
            var employee = new EmployeeModel
            {
                EmployeeId = viewModel.EmployeeId,
                GlobalId = viewModel.GlobalId,
                CardId = viewModel.CardId,
                EmployeeType = viewModel.EmployeeType,
                Title = viewModel.Title,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                FirstNameThai = viewModel.FirstNameThai,
                LastNameThai = viewModel.LastNameThai,
                Gender = viewModel.Gender,
                BirthDate = viewModel.BirthDate,
                HireDate = viewModel.HireDate,
                AvailableFlag = true,
                ChangedDate = DateTime.Now,
            };

            await _employeeService.AddAsync(employee);
        }

        public async Task<IEnumerable<SelectListItem>> GetDepartments()
        {
            var departments = await _departmentService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var department in departments)
            {
                item.Add(new SelectListItem()
                {
                    Value = department.DepartmentId.ToString(),
                    Text = department.DepartmentName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetSections()
        {
            var sections = await _sectionService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "", Selected = true}
            };

            foreach (var section in sections)
            {
                item.Add(new SelectListItem()
                {
                    Value = section.SectionId.ToString(),
                    Text = section.SectionName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetJobTitles()
        {
            var jobTitles = await _jobService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var job in jobTitles)
            {
                item.Add(new SelectListItem()
                {
                    Value = job.JobTitleId.ToString(),
                    Text = job.JobTitle
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetLevels()
        {
            var levels = await _levelService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var level in levels)
            {
                item.Add(new SelectListItem()
                {
                    Value = level.LevelId.ToString(),
                    Text = level.LevelName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetShifts()
        {
            var shifts = await _shiftService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var shift in shifts)
            {
                item.Add(new SelectListItem()
                {
                    Value = shift.ShiftId.ToString(),
                    Text = shift.ShiftName
                });
            }

            return item;
        }
    }
}
