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
    public class EducationMajorService : IEducationMajorService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterEducationMajor> _repository;

        public EducationMajorService(IAsyncRepository<MasterEducationMajor> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterEducationMajor, EducationMajorModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<EducationMajorModel> GetByIdAsync(int id)
        {
            var major = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterEducationMajor, EducationMajorModel>(major);
        }

        public async Task<List<EducationMajorModel>> GetAllAsync()
        {
            var majors = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterEducationMajor>, List<EducationMajorModel>>(majors);
        }

        public async Task<List<EducationMajorModel>> GetByNameAsync(string name)
        {
            var majors = await _repository.GetAsync(x => x.MarjorName == name);
            return _mapper.Map<List<MasterEducationMajor>, List<EducationMajorModel>>(majors);
        }

        public async Task AddAsync(EducationMajorModel model)
        {
            var major = new MasterEducationMajor
            {
                DegreeId = model.DegreeId,
                MarjorName = model.MarjorName,
                MajorNameThai = model.MajorNameThai
            };

            await _repository.AddAsync(major);
        }

        public async Task UpdateAsync(EducationMajorModel model)
        {
            var major = await _repository.GetByIdAsync(model.MajorId);

            major.DegreeId = model.DegreeId;
            major.MarjorName = model.MarjorName;
            major.MajorNameThai = model.MajorNameThai;

            await _repository.UpdateAsync(major);
        }

        public async Task DeleteAsync(int id)
        {
            var major = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(major);
        }
    }
}
