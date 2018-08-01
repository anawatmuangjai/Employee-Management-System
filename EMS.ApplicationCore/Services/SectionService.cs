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
    public class SectionService : BaseService<SectionModel, MasterSection, IAsyncRepository<MasterSection>>, ISectionService
    {
        public SectionService(IAsyncRepository<MasterSection> repository)
            : base(repository)
        {
        }

        public async Task<List<SectionModel>> GetSectionAsync(string name)
        {
            var sectionSpec = new SectionSpecification(name);

            var entities = await _repository.GetAsync(sectionSpec);

            var model = entities.Select(x => new SectionModel
            {
                SectionId = x.SectionId,
                DepartmentName = x.Department.DepartmentName,
                SectionName = x.SectionName,
                SectionCode = x.SectionCode,
                DepartmentId = x.DepartmentId
            });

            return model.ToList();
        }
    }
}
