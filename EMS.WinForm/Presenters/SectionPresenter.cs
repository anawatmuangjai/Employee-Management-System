using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
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
        private readonly ISectionService _sectionService;

        public SectionPresenter(ISectionView view, ISectionService sectionService)
        {
            _view = view;
            _view.Presenter = this;
            _sectionService = sectionService;
        }

        public ISectionView GetView()
        {
            return _view;
        }

        public async Task GetDepartments()
        {
            var departments = await _sectionService.GetAllDepartmentAsync();
            _view.Departments = departments.ToList();
        }

        public async Task ViewAll()
        {
            var sections = await _sectionService.GetAllSectionAsync();
            _view.Sections = sections.ToList();
        }

        public async Task Search()
        {
            var sections = await _sectionService.GetByNameAsync(_view.Filter);
            _view.Sections = sections.ToList();
        }

        public async Task Save()
        {
            var section = new SectionModel
            {
                SectionId = _view.SectionID,
                DepartmentId = _view.DepartmentID,
                SectionName = _view.SectionName,
                SectionCode = _view.SectionCode,
            };

            if (section.SectionId > 0)
                await _sectionService.UpdateAsync(section);
            else
                await _sectionService.AddAsync(section);
        }

        public void Delete()
        {
            _sectionService.DeleteAsync(_view.SelectedSection.SectionId);
        }


    }
}
