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
    public class DepartmentPresenter : IDepartmentPresenter
    {
        private readonly IDepartmentView _view;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentPresenter(IDepartmentView view, IDepartmentRepository departmentRepository)
        {
            _view = view;
            _view.Presenter = this;
            _departmentRepository = departmentRepository;
        }

        public IDepartmentView GetView()
        {
            return _view;
        }

        public void ViewAll()
        {
            _view.Departments = _departmentRepository.GetAll().ToList();
        }

        public void Search()
        {
            _view.Departments = _departmentRepository.GetByName(_view.Filter).ToList();
        }

        public void Save()
        {
            var department = new DepartmentDto
            {
                DepartmentID = _view.DepartmentId,
                DepartmentName = _view.DepartmentName,
                DepartmentCode = _view.DepartmentCode,
                DepartmentGroup = _view.DepartmentGroup
            };

            if (department.DepartmentID > 0)
                _departmentRepository.Update(department);
            else
                _departmentRepository.Add(department);
        }

        public void Delete()
        {
            if (_view.SelectedDepartment == null)
                return;

            _departmentRepository.Delete(_view.SelectedDepartment);
        }


    }
}
