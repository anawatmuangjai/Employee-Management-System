using EMS.Core.Dtos;
using EMS.Core.Interfaces;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class SectionPresenter : ISectionPresenter
    {
        private readonly ISectionView _view;
        private readonly ISectionRepository _sectionRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public SectionPresenter(
            ISectionView view,
            ISectionRepository sectionRepository,
            IDepartmentRepository departmentRepository)
        {
            _view = view;
            _view.Presenter = this;
            _sectionRepository = sectionRepository;
            _departmentRepository = departmentRepository;
        }

        public ISectionView GetView()
        {
            return _view;
        }

        public void GetDepartments()
        {
            _view.Departments = _departmentRepository.GetAll().ToList();
        }

        public void ViewAll()
        {
            _view.Sections = _sectionRepository.GetAll().ToList();
        }

        public void Search()
        {
            _view.Sections = _sectionRepository.GetByName(_view.Filter).ToList();
        }

        public void Save()
        {
            var section = new SectionDto
            {
                SectionID = _view.SectionID,
                DepartmentID = _view.DepartmentID,
                SectionName = _view.SectionName,
                SectionCode = _view.SectionCode,
                Department = _view.SelectedDepartment
            };

            if (section.SectionID > 0)
                _sectionRepository.Update(section);
            else
                _sectionRepository.Add(section);
        }

        public void Delete()
        {
            _sectionRepository.Delete(_view.SelectedSection);
        }


    }
}
