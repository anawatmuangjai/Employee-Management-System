using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
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
        private readonly IAsyncRepository<MasterSection> _sectionRepository;
        private readonly IAsyncRepository<MasterDepartment> _departmentRepository;

        public SectionPresenter(ISectionView view,
            IAsyncRepository<MasterSection> sectionRepository,
            IAsyncRepository<MasterDepartment> departmentRepository)
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

        public async Task GetDepartments()
        {
            _view.Departments = await _departmentRepository.GetAllAsync();
        }

        public async Task ViewAll()
        {
            _view.Sections =  await _sectionRepository.GetAllAsync();
        }

        public void Search()
        {
            //_view.Sections = _sectionRepository.GetByNameWithDepartment(_view.Filter).ToList();
        }

        public async Task Save()
        {
            var section = new MasterSection
            {
                SectionId = _view.SectionID,
                DepartmentId = _view.DepartmentID,
                SectionName = _view.SectionName,
                SectionCode = _view.SectionCode,
            };

            if (section.SectionId > 0)
                await _sectionRepository.UpdateAsync(section);
            else
                await _sectionRepository.AddAsync(section);
        }

        public void Delete()
        {
            _sectionRepository.DeleteAsync(_view.SelectedSection);
        }


    }
}
