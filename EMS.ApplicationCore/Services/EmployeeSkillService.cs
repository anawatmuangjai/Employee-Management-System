using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Specifications;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<EmployeSkills> _repository;

        public EmployeeSkillService(IAsyncRepository<EmployeSkills> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<EmployeSkills, EmployeeSkillModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<List<EmployeeSkillModel>> GetByEmployeeId(string employeeId)
        {
            var spec = new EmployeeSkillSpecification(x => x.EmployeeId == employeeId);
            var employeeSkills = await _repository.GetAsync(spec);
            return _mapper.Map<List<EmployeSkills>, List<EmployeeSkillModel>>(employeeSkills);
        }

        public async Task AddAsync(EmployeeSkillModel model)
        {
            var employeSkills = new EmployeSkills
            {
                EmployeeId = model.EmployeeId,
                SkillId = model.SkillId,
                SkillLevel = model.SkillLevel
            };

            await _repository.AddAsync(employeSkills);
        }

        public async Task UpdateAsync(EmployeeSkillModel model)
        {
            var employeSkills = await _repository.GetSingleAsync(x => x.EmployeeId == model.EmployeeId && x.SkillId == model.SkillId);

            employeSkills.SkillLevel = model.SkillLevel;

            await _repository.UpdateAsync(employeSkills);
        }

        public async Task DeleteAsync(string employeeId,int skillId)
        {
            var employeSkills = await _repository.GetSingleAsync(x => x.EmployeeId == employeeId && x.SkillId == skillId);
            await _repository.DeleteAsync(employeSkills);
        }
    }
}
