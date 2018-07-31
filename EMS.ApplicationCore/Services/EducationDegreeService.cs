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
        private readonly IAsyncRepository<MasterEducationDegree> _repository;

        public EducationDegreeService(IAsyncRepository<MasterEducationDegree> repository)
        {
            _repository = repository;
        }

        public async Task<List<EducationDegreeModel>> GetAllAsync()
        {
            var degree = await _repository.GetAllAsync();
            return MappingDegreeModel(degree);
        }

        public async Task<List<EducationDegreeModel>> GetByNameAsync(string name)
        {
            var degree = await _repository.GetAsync(x => x.DegreeName.Contains(name));
            return MappingDegreeModel(degree);
        }

        public async Task<EducationDegreeModel> AddAsync(EducationDegreeModel model)
        {
            var degree = new MasterEducationDegree
            {
                DegreeName = model.DegreeName,
                DegreeNameThai = model.DegreeNameThai
            };

            degree = await _repository.AddAsync(degree);
            return MappingDegreeModel(degree);
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

        private List<EducationDegreeModel> MappingDegreeModel(List<MasterEducationDegree> degrees)
        {
            return degrees.Select(x => new EducationDegreeModel
            {
                DegreeId = x.DegreeId,
                DegreeName = x.DegreeName,
                DegreeNameThai = x.DegreeNameThai
            }).ToList();
        }

        private EducationDegreeModel MappingDegreeModel(MasterEducationDegree degree)
        {
            return new EducationDegreeModel
            {
                DegreeId = degree.DegreeId,
                DegreeName = degree.DegreeName,
                DegreeNameThai = degree.DegreeNameThai
            };
        }
    }
}
