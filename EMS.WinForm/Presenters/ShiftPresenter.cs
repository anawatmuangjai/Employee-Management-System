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
    public class ShiftPresenter : IShiftPresenter
    {
        private readonly IShiftView _view;
        private readonly IShiftService _shiftService;

        public ShiftPresenter(
            IShiftView view,
            IShiftService shiftService)
        {
            _view = view;
            _view.Presenter = this;
            _shiftService = shiftService;
        }

        public IShiftView GetView()
        {
            return _view;
        }

        public async Task ViewAllAsync()
        {
            _view.Shifts = await _shiftService.GetAllAsync();
        }

        public async Task SaveAsync()
        {
            var shift = new ShiftModel
            {
                ShiftId = _view.ShiftId,
                ShiftName = _view.ShiftName,
                StartTime = _view.StartTime,
                EndTime = _view.EndTime
            };

            if (shift.ShiftId > 0)
                await _shiftService.UpdateAsync(shift);
            else
                await _shiftService.AddAsync(shift);
        }

        public async Task DeleteAsync()
        {
            await _shiftService.DeleteAsync(_view.SelectedShift);
        }
    }
}
