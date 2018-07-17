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
    public class ShiftPresenter : IShiftPresenter
    {
        private readonly IShiftView _view;
        private readonly IAsyncRepository<MasterShift> _shiftRepository;

        public ShiftPresenter(
            IShiftView view, 
            IAsyncRepository<MasterShift> shiftRepository)
        {
            _view = view;
            _view.Presenter = this;
            _shiftRepository = shiftRepository;
        }

        public IShiftView GetView()
        {
            return _view;
        }
    }
}
