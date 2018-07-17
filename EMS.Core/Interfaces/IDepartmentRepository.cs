using EMS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentDto> GetAll();
        IEnumerable<DepartmentDto> GetByName(string name);
        DepartmentDto GetById(int id);
        DepartmentDto Add(DepartmentDto department);
        void Update(DepartmentDto department);
        void Delete(DepartmentDto department);
    }
}
