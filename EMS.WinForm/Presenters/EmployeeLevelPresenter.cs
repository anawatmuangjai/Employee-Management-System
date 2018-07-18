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
    public class EmployeeLevelPresenter : IEmployeeLevelPresenter
    {
        private readonly IEmployeeLevelView _view;
        private readonly IEmployeeLevelService _employeeLevelService;

        public EmployeeLevelPresenter(
            IEmployeeLevelView view, 
            IEmployeeLevelService employeeLevelService)
        {
            _view = view;
            _view.Presenter = this;
            _employeeLevelService = employeeLevelService;
        }

        public IEmployeeLevelView GetView()
        {
            return _view;
        }

        public async Task ViewAllAsync()
        {
            _view.Levels = await _employeeLevelService.GetAllAsync();
        }

        public async Task SaveAsync()
        {
            var employeeLevel = new EmployeeLevelModel
            {
                LevelId = _view.LevelId,
                LevelName = _view.LevelName,
                LevelCode = _view.LevelCode
            };

            if (employeeLevel.LevelId > 0)
                await _employeeLevelService.UpdateAsync(employeeLevel);
            else
                await _employeeLevelService.AddAsync(employeeLevel);
        }

        public async Task DeleteAsync()
        {
            await _employeeLevelService.DeleteAsync(_view.SelectedLevel);
        }
    }
}
