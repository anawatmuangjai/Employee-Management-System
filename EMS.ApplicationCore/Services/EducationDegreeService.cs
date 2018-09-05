using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class EducationDegreeService : IEducationDegreeService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterEducationDegree> _repository;

        public EducationDegreeService(IAsyncRepository<MasterEducationDegree> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterEducationDegree, EducationDegreeModel>());

            _mapper = config.CreateMapper();
        }


        public async Task<EducationDegreeModel> GetByIdAsync(int id)
        {
            var degree = await _repository.GetByIdAsync(id);
            return _mapper.Map<MasterEducationDegree, EducationDegreeModel>(degree);
        }

        public async Task<List<EducationDegreeModel>> GetAllAsync()
        {
            var degree = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterEducationDegree>, List<EducationDegreeModel>>(degree);
        }

        public async Task<List<EducationDegreeModel>> GetByNameAsync(string name)
        {
            var degree = await _repository.GetAsync(x => x.DegreeName.Contains(name));
            return _mapper.Map<List<MasterEducationDegree>, List<EducationDegreeModel>>(degree);
        }

        public async Task<EducationDegreeModel> AddAsync(EducationDegreeModel model)
        {
            var degree = new MasterEducationDegree
            {
                DegreeName = model.DegreeName,
                DegreeNameThai = model.DegreeNameThai
            };

            degree = await _repository.AddAsync(degree);
            return _mapper.Map<MasterEducationDegree, EducationDegreeModel>(degree);
        }

        public async Task UpdateAsync(EducationDegreeModel model)
        {
            var degree = await _repository.GetByIdAsync(model.DegreeId);

            degree.DegreeName = model.DegreeName;
            degree.DegreeNameThai = model.DegreeNameThai;

            await _repository.UpdateAsync(degree);
        }

        public async Task DeleteAsync(int id)
        {
            var degree = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(degree);
        }
    }
}
