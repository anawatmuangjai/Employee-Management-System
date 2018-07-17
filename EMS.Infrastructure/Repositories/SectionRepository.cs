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
    public class SectionRepository : ISectionRepository
    {
        private readonly IMapper _mapper;
        private readonly EmployeeContext _context;

        public SectionRepository()
            : this(new EmployeeContext())
        {
        }

        public SectionRepository(EmployeeContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MasterSection, SectionDto>()
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.MasterDepartment.DepartmentName))
                .ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public IEnumerable<SectionDto> GetAll()
        {
            var entities = _context.MasterSections
                .Include(x => x.MasterDepartment)
                .ToList();

            return _mapper.Map<List<MasterSection>, List<SectionDto>>(entities);
        }

        public IEnumerable<SectionDto> GetByName(string name)
        {
            var entities = _context.MasterSections
                .Where(x => x.SectionName.Contains(name))
                .Include(x => x.MasterDepartment)
                .ToList();

            return _mapper.Map<List<MasterSection>, List<SectionDto>>(entities);
        }

        public SectionDto GetById(int id)
        {
            var entity = _context.MasterSections.SingleOrDefault(x => x.DepartmentID == id);
            return _mapper.Map<MasterSection, SectionDto>(entity);
        }

        public SectionDto Add(SectionDto section)
        {
            var entity = _mapper.Map<SectionDto, MasterSection>(section);

            _context.MasterSections.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<MasterSection, SectionDto>(entity);
        }

        public void Update(SectionDto section)
        {
            var newEntity = _mapper.Map<SectionDto, MasterSection>(section);
            var entity = _context.MasterSections.SingleOrDefault(x => x.SectionID == newEntity.SectionID);

            _context.Entry(entity).CurrentValues.SetValues(newEntity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(SectionDto section)
        {
            var entity = _context.MasterSections.Find(section.SectionID);

            _context.MasterSections.Remove(entity);
            _context.SaveChanges();
        }
    }
}
