using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public IMainView GetView()
        {
            return _view;
        }

        public void ShowView()
        {
            _view.ShowView();
        }
    }
}
