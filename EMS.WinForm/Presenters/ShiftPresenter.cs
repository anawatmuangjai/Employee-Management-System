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

        public ShiftPresenter(IShiftView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public IShiftView GetView()
        {
            return _view;
        }
    }
}
