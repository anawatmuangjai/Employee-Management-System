using EMS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Interfaces
{
    public interface ISectionRepository
    {
        IEnumerable<SectionDto> GetAll();
        IEnumerable<SectionDto> GetByName(string name);
        SectionDto GetById(int id);
        SectionDto Add(SectionDto section);
        void Update(SectionDto section);
        void Delete(SectionDto section);
    }
}
