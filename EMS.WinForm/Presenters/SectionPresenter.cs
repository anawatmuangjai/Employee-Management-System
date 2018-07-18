﻿using EMS.ApplicationCore.Interfaces.Services;
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
        private readonly IDepartmentService _departmentService;

        public SectionPresenter(
            ISectionView view, 
            ISectionService sectionService, 
            IDepartmentService departmentService)
        {
            _view = view;
            _view.Presenter = this;
            _sectionService = sectionService;
            _departmentService = departmentService;
        }

        public ISectionView GetView()
        {
            return _view;
        }

        public async Task GetDepartmentsAsync()
        {
            var departments = await _departmentService.GetAllAsync();
            _view.Departments = departments;
        }

        public async Task ViewAllAsync()
        {
            var sections = await _sectionService.GetAllWithDepartmentAsync();
            _view.Sections = sections;
        }

        public async Task SearchAsync()
        {
            var sections = await _sectionService.GetByNameAsync(_view.Filter);
            _view.Sections = sections;
        }

        public async Task SaveAsync()
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

        public void DeleteAsync()
        {
            _sectionService.DeleteAsync(_view.SelectedSection);
        }
    }
}
