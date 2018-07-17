using AutoMapper;
using EMS.Core.Dtos;
using EMS.Core.Interfaces;
using EMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IMapper _mapper;
        private readonly EmployeeContext _context;

        public DepartmentRepository()
            : this(new EmployeeContext())
        {
        }

        public DepartmentRepository(EmployeeContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MasterDepartment, DepartmentDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var entities = _context.MasterDepartments.ToList();
            return _mapper.Map<List<MasterDepartment>, List<DepartmentDto>>(entities);
        }

        public IEnumerable<DepartmentDto> GetByName(string name)
        {
            var entities = _context.MasterDepartments.Where(x => x.DepartmentName.Contains(name)).ToList();
            return _mapper.Map<List<MasterDepartment>, List<DepartmentDto>>(entities);
        }

        public DepartmentDto GetById(int id)
        {
            var entity = _context.MasterDepartments.SingleOrDefault(x => x.DepartmentID == id);
            return _mapper.Map<MasterDepartment, DepartmentDto>(entity);
        }

        public DepartmentDto Add(DepartmentDto department)
        {
            var entity = _mapper.Map<DepartmentDto, MasterDepartment>(department);

            _context.MasterDepartments.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<MasterDepartment, DepartmentDto>(entity);
        }

        public void Update(DepartmentDto department)
        {
            var newEntity = _mapper.Map<DepartmentDto, MasterDepartment>(department);
            var entity = _context.MasterDepartments.SingleOrDefault(x => x.DepartmentID == newEntity.DepartmentID);

            _context.Entry(entity).CurrentValues.SetValues(newEntity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(DepartmentDto department)
        {
            var entity = _context.MasterDepartments.Find(department.DepartmentID);

            _context.MasterDepartments.Remove(entity);
            _context.SaveChanges();
        }
    }
}
