using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
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
    public class DepartmentPresenter : IDepartmentPresenter
    {
        private readonly IDepartmentView _view;
        private readonly IDepartmentService _departmentService;

        public DepartmentPresenter(IDepartmentView view, IDepartmentService departmentService)
        {
            _view = view;
            _view.Presenter = this;
            _departmentService = departmentService;
        }

        public IDepartmentView GetView()
        {
            return _view;
        }

        public async Task ViewAllAsync()
        {
            _view.Departments = await _departmentService.GetAllAsync();
        }

        public async Task SearchAsync()
        {
            _view.Departments = await _departmentService.GetByNameAsync(_view.Filter);
        }

        public async Task SaveAsync()
        {
            var department = new DepartmentModel
            {
                DepartmentId = _view.DepartmentId,
                DepartmentName = _view.DepartmentName,
                DepartmentCode = _view.DepartmentCode,
                DepartmentGroup = _view.DepartmentGroup
            };

            if (department.DepartmentId > 0)
                await _departmentService.UpdateAsync(department);
            else
                await _departmentService.AddAsync(department);
        }

        public async Task DeleteAsync()
        {
            await _departmentService.DeleteAsync(_view.SelectedDepartment);
        }
    }
}
