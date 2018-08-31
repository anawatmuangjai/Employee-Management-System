using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Specifications;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Employee> _employeeRepository;

        public EmployeeService(IAsyncRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return MappingEmployeeModels(employees);
        }

        public async Task<List<EmployeeModel>> GetByNameAsync(string name)
        {
            var employees = await _employeeRepository.GetAsync(x => x.FirstName.Contains(name));
            return MappingEmployeeModels(employees);
        }

        public async Task<EmployeeModel> GetByEmployeeIdAsync(string employeeId)
        {
            var employees = await _employeeRepository.GetSingleAsync(x => x.EmployeeId == employeeId);
            return MappingEmployeeModel(employees);
        }

        public async Task<EmployeeModel> GetByEmployeeIdWithDetailAsync(string employeeId)
        {
            var spec = new EmployeeFilterSpecification(employeeId);
            var employees = await _employeeRepository.GetSingleAsync(spec);
            return _mapper.Map<Employee, EmployeeModel>(employees);
        }

        public async Task<bool> ExistsAsync(string employeeId)
        {
            return await _employeeRepository.ExistsAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<EmployeeModel> AddAsync(EmployeeModel model)
        {
            var entity = new Employee
            {
                EmployeeId = model.EmployeeId,
                GlobalId = model.GlobalId,
                CardId = model.CardId,
                EmployeeType = model.EmployeeType,
                Title = model.Title,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FirstNameThai = model.FirstNameThai,
                LastNameThai = model.LastNameThai,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                HireDate = model.HireDate,
                AvailableFlag = model.AvailableFlag,
                ChangedDate = model.ChangedDate,
            };

            entity = await _employeeRepository.AddAsync(entity);
            return MappingEmployeeModel(entity);
        }

        public async Task UpdateAsync(EmployeeModel model)
        {
            var entity = await _employeeRepository.GetSingleAsync(x => x.EmployeeId == model.EmployeeId);

            entity.GlobalId = model.GlobalId;
            entity.CardId = model.CardId;
            entity.EmployeeType = model.EmployeeType;
            entity.Title = model.Title;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.FirstNameThai = model.FirstNameThai;
            entity.LastNameThai = model.LastNameThai;
            entity.Gender = model.Gender;
            entity.AvailableFlag = model.AvailableFlag;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.ChangedDate = model.ChangedDate;

            await _employeeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(entity);
        }

        private List<EmployeeModel> MappingEmployeeModels(List<Employee> employees)
        {
            return employees.Select(x => new EmployeeModel
            {
                EmployeeId = x.EmployeeId,
                GlobalId = x.GlobalId,
                CardId = x.CardId,
                EmployeeType = x.EmployeeType,
                Title = x.Title,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FirstNameThai = x.FirstNameThai,
                LastNameThai = x.LastNameThai,
                Gender = x.Gender,
                AvailableFlag = x.AvailableFlag,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                ChangedDate = x.ChangedDate,
            }).ToList();
        }

        private EmployeeModel MappingEmployeeModel(Employee employee)
        {
            return new EmployeeModel
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
                AvailableFlag = employee.AvailableFlag,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                ChangedDate = employee.ChangedDate,
            };
        }

    }
}
