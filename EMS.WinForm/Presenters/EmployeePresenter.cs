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
    public class EmployeePresenter : IEmployeePresenter
    {
        private readonly IEmployeeView _view;
        private readonly IAsyncRepository<Employee> _employeeRepository;

        public EmployeePresenter(IEmployeeView view, IAsyncRepository<Employee> employeeRepository)
        {
            _view = view;
            _view.Presenter = this;
            _employeeRepository = employeeRepository;
        }

        public IEmployeeView GetView()
        {
            return _view;
        }

        public async Task SaveAsync()
        {
            var employee = new Employee
            {
                EmployeeId = _view.EmployeeId,
                GlobalId = _view.GlobalId,
                CardId = _view.CardId,
                EmployeeType = _view.EmployeeType,
                Title = _view.Title,
                FirstName = _view.FirstName,
                LastName = _view.LastName,
                FirstNameThai = _view.FirstNameThai,
                LastNameThai = _view.LastNameThai,
                Gender = _view.Gender,
                AvailableFlag = _view.AvailableFlag,
                HireDate = _view.HireDate,
                ChangedDate = _view.ChangedDate,
            };

            if (employee.EmployeeId > 0)
                await _employeeRepository.UpdateAsync(employee);
            else
                await _employeeRepository.AddAsync(employee);
        }
    }
}
