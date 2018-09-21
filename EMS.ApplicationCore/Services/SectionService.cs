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
    public class SectionService : ISectionService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterSection> _repository;

        public SectionService(IAsyncRepository<MasterSection> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterSection, SectionModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<SectionModel> GetByIdAsync(int id)
        {
            var section = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterSection, SectionModel>(section);
        }

        public async Task<List<SectionModel>> GetAllAsync()
        {
            var spec = new SectionSpecification(x => x.SectionName != null);
            var sections = await _repository.GetAsync(spec);

            //var sections = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterSection>, List<SectionModel>>(sections);
        }

        public async Task<List<SectionModel>> GetByNameAsync(string name)
        {
            var sections = await _repository.GetAsync(x => x.SectionName == name);
            return _mapper.Map<List<MasterSection>, List<SectionModel>>(sections);
        }

        public async Task<List<SectionModel>> GetByDepartmentIdAsync(int departmentId)
        {
            var sections = await _repository.GetAsync(x => x.DepartmentId == departmentId);
            return _mapper.Map<List<MasterSection>, List<SectionModel>>(sections);
        }

        public async Task AddAsync(SectionModel model)
        {
            var section = new MasterSection
            {
                DepartmentId = model.DepartmentId,
                SectionName = model.SectionName,
                SectionCode = model.SectionCode,
            };

            await _repository.AddAsync(section);
        }

        public async Task UpdateAsync(SectionModel model)
        {
            var section = await _repository.GetByIdAsync(model.SectionId);

            section.DepartmentId = model.DepartmentId;
            section.SectionName = model.SectionName;
            section.SectionCode = model.SectionCode;

            await _repository.UpdateAsync(section);
        }

        public async Task DeleteAsync(int id)
        {
            var section = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(section);
        }


    }
}
