using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class LoginPresenter : ILoginPresenter
    {
        private readonly ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public ILoginView GetView()
        {
            return _view;
        }

        public void ShowView()
        {
            _view.ShowView();
        }

        public void Login()
        {
            var username = _view.Username;
            var password = _view.Password;



            _view.ShowMainView();
        }
    }
}
