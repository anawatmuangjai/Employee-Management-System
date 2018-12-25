﻿using AutoMapper;
using EMS.ApplicationCore.Helper;
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
            return _mapper.Map<List<Employee>, List<EmployeeModel>>(employees);
        }

        public async Task<List<EmployeeModel>> GetByNameAsync(string name)
        {
            var employees = await _employeeRepository.GetAsync(x => x.FirstName.Contains(name));
            return _mapper.Map<List<Employee>, List<EmployeeModel>>(employees);
        }

        public async Task<List<EmployeeModel>> GetAsync(EmployeeFilter filter)
        {
            var spec = new EmployeeSpecification(x => (!filter.DepartmentId.HasValue || x.EmployeeState.JobFunction.Section.DepartmentId == filter.DepartmentId)
             && (string.IsNullOrEmpty(filter.EmployeeName) || (x.FirstName.Contains(filter.EmployeeName) || x.FirstNameThai.Contains(filter.EmployeeName)))
             && (string.IsNullOrEmpty(filter.EmployeeId) || x.EmployeeId == filter.EmployeeId)
             && (string.IsNullOrEmpty(filter.EmployeeGroup) || x.EmployeeType == filter.EmployeeGroup)
             && (!filter.SectionId.HasValue || x.EmployeeState.JobFunction.SectionId == filter.SectionId)
             && (!filter.FunctionId.HasValue || x.EmployeeState.JobFunctionId == filter.FunctionId)
             && (!filter.ShiftId.HasValue || x.EmployeeState.ShiftId == filter.ShiftId)
             && (!filter.LevelId.HasValue || x.EmployeeState.LevelId == filter.LevelId)
             && (!filter.PositionId.HasValue || x.EmployeeState.PositionId == filter.PositionId)
             && (!filter.AvailableFlag.HasValue || x.AvailableFlag == filter.AvailableFlag));

            var employees = await _employeeRepository.GetAsync(spec);
            return _mapper.Map<List<Employee>, List<EmployeeModel>>(employees);
        }

        public async Task<EmployeeModel> GetByEmployeeIdAsync(string employeeId)
        {
            var employee = await _employeeRepository.GetSingleAsync(x => x.EmployeeId == employeeId);
            return _mapper.Map<Employee, EmployeeModel>(employee);
        }

        public async Task<EmployeeModel> GetByEmployeeIdWithDetailAsync(string employeeId)
        {
            var spec = new EmployeeSpecification(x => x.EmployeeId == employeeId);
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
                TitleThai = model.TitleThai,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FirstNameThai = model.FirstNameThai,
                LastNameThai = model.LastNameThai,
                Gender = model.Gender,
                Height = model.Height,
                Hand = model.Hand,
                BirthDate = model.BirthDate,
                HireType = model.HireType,
                HireDate = model.HireDate,
                AvailableFlag = model.AvailableFlag,
                ChangedDate = model.ChangedDate,
            };

            entity = await _employeeRepository.AddAsync(entity);
            return _mapper.Map<Employee, EmployeeModel>(entity);
        }

        public async Task UpdateAsync(EmployeeModel model)
        {
            var entity = await _employeeRepository.GetSingleAsync(x => x.EmployeeId == model.EmployeeId);

            entity.GlobalId = model.GlobalId;
            entity.CardId = model.CardId;
            entity.EmployeeType = model.EmployeeType;
            entity.Title = model.Title;
            entity.TitleThai = model.TitleThai;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.FirstNameThai = model.FirstNameThai;
            entity.LastNameThai = model.LastNameThai;
            entity.Gender = model.Gender;
            entity.Height = model.Height;
            entity.Hand = model.Hand;
            entity.AvailableFlag = model.AvailableFlag;
            entity.BirthDate = model.BirthDate;
            entity.HireType = model.HireType;
            entity.HireDate = model.HireDate;
            entity.ChangedDate = model.ChangedDate;

            await _employeeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _employeeRepository.GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(entity);
        }

        public async Task<int> CountTotalEmployeeAsync()
        {
            return await _employeeRepository.CountAsync(x => x.AvailableFlag == true);
        }


    }
}
