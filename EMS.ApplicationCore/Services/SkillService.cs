using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterSkill> _repository;

        public SkillService(IAsyncRepository<MasterSkill> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterSkill, SkillModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<SkillModel> GetByIdAsync(int id)
        {
            var skill = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterSkill, SkillModel>(skill);
        }

        public async Task<List<SkillModel>> GetAsync(int skillGroupId, int skillTypeId)
        {
            var skills = await _repository.GetAsync(x => x.SkillGroupId == skillGroupId && x.SkillTypeId == skillTypeId);
            return _mapper.Map<List<MasterSkill>, List<SkillModel>>(skills);
        }

        public async Task<List<SkillModel>> GetAllAsync()
        {
            var skills = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterSkill>, List<SkillModel>>(skills);
        }

        public async Task AddAsync(SkillModel model)
        {
            var skill = new MasterSkill
            {
                SkillGroupId = model.SkillGroupId,
                SkillTypeId = model.SkillTypeId,
                SkillName = model.SkillName,
                SkillDescription = model.SkillDescription
            };

            await _repository.AddAsync(skill);
        }

        public async Task UpdateAsync(SkillModel model)
        {
            var skill = await _repository.GetByIdAsync(model.SkillId);

            skill.SkillGroupId = model.SkillGroupId;
            skill.SkillTypeId = model.SkillTypeId;
            skill.SkillName = model.SkillName;
            skill.SkillDescription = model.SkillDescription;

            await _repository.UpdateAsync(skill);
        }

        public async Task DeleteAsync(int id)
        {
            var route = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(route);
        }


    }
}
