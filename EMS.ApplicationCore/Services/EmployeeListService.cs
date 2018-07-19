using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class EmployeeListService : IEmployeeListService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeListService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeListModel>> GetAllAsync()
        {
            var entities = await _employeeRepository.GetEmployeeListAsync();

            var result = entities.Select(x => new EmployeeListModel
            {
                EmployeeId = x.EmployeeId,
                EmployeeType = x.EmployeeType,
                GlobalId = x.GlobalId,
                Title = x.Title,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FirstNameThai = x.FirstNameThai,
                LastNameThai = x.LastNameThai,
                Gender = x.Gender,
                JobTitle = x.EmployeeState.Job.JobTitle,
                DepartmentName = x.EmployeeState.Department.DepartmentName,
                HireDate = x.HireDate,
                ChangedDate = x.ChangedDate,
                Images = x.EmployeeImage.Select(i => i.Images).FirstOrDefault()
            }).ToList();

            return result;
        }
    }
}
