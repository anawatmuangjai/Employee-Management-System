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
    public class DepartmentPresenter : IDepartmentPresenter
    {
        private readonly IDepartmentView _view;
        private readonly IAsyncRepository<MasterDepartment> _departmentRepository;

        public DepartmentPresenter(
            IDepartmentView view,
            IAsyncRepository<MasterDepartment> departmentRepository)
        {
            _view = view;
            _view.Presenter = this;
            _departmentRepository = departmentRepository;
        }

        public IDepartmentView GetView()
        {
            return _view;
        }

        public async Task ViewAll()
        {
            _view.Departments = await _departmentRepository.GetAllAsync();
        }

        public void Search()
        {
           // _view.Departments = _departmentRepository.GetByName(_view.Filter).ToList();
        }

        public async Task Save()
        {
            var department = new MasterDepartment
            {
                DepartmentId = _view.DepartmentId,
                DepartmentName = _view.DepartmentName,
                DepartmentCode = _view.DepartmentCode,
                DepartmentGroup = _view.DepartmentGroup
            };

            if (department.DepartmentId > 0)
                await _departmentRepository.UpdateAsync(department);
            else
                await _departmentRepository.AddAsync(department);
        }

        public async Task Delete()
        {
            if (_view.SelectedDepartment == null)
                return;

            await _departmentRepository.DeleteAsync(_view.SelectedDepartment);
        }


    }
}
