using EMS.ApplicationCore.Interfaces.Services;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class EmployeeListPresenter : IEmployeeListPresenter
    {
        private readonly IEmployeeListView _view;
        private readonly IEmployeeListService _employeeListService;

        public EmployeeListPresenter(IEmployeeListView view, IEmployeeListService employeeListService)
        {
            _view = view;
            _view.Presenter = this;
            _employeeListService = employeeListService;
        }

        public IEmployeeListView GetView()
        {
            return _view;
        }

        public async Task ViewAllAsync()
        {
            _view.Employees = await _employeeListService.GetAllAsync();
        }
    }
}
