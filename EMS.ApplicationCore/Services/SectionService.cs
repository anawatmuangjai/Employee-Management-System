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
    public class SectionService : ISectionService
    {
        private readonly IAsyncRepository<MasterSection> _sectionRepository;
        private readonly IAsyncRepository<MasterDepartment> _departmentRepository;

        public SectionService(
            IAsyncRepository<MasterSection> sectionRepository,
            IAsyncRepository<MasterDepartment> departmentRepository)
        {
            _sectionRepository = sectionRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartmentAsync()
        {
            var sections = await _departmentRepository.GetAllAsync();

            return sections.Select(x => new DepartmentModel
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                DepartmentCode = x.DepartmentCode,
                DepartmentGroup = x.DepartmentGroup
            });
        }

        public async Task<IEnumerable<SectionModel>> GetAllSectionAsync()
        {
            var sections = await _sectionRepository.GetAllAsync();

            return sections.Select(x => new SectionModel
            {
                SectionId = x.SectionId,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                SectionName = x.SectionName,
                SectionCode = x.SectionCode
            });
        }

        public async Task<IEnumerable<SectionModel>> GetByNameAsync(string name)
        {
            var sections = await _sectionRepository.GetAsync(x => x.SectionName.Contains(name));

            return sections.Select(x => new SectionModel
            {
                SectionId = x.SectionId,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName,
                SectionName = x.SectionName,
                SectionCode = x.SectionCode
            });
        }

        public async Task AddAsync(SectionModel model)
        {
            var entity = new MasterSection
            {
                SectionId = model.SectionId,
                DepartmentId = model.DepartmentId,
                SectionName = model.SectionName,
                SectionCode = model.SectionCode
            };

            await _sectionRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(SectionModel model)
        {
            var entity = await _sectionRepository.GetByIdAsync(model.SectionId);

            entity.DepartmentId = model.DepartmentId;
            entity.SectionName = model.SectionName;
            entity.SectionCode = model.SectionCode;

            await _sectionRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int sectionId)
        {
            var entity = await _sectionRepository.GetByIdAsync(sectionId);

            await _sectionRepository.DeleteAsync(entity);
        }


    }
}
