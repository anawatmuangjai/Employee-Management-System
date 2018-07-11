using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class RegistrationPresenter : IRegistrationPresenter
    {
        private readonly IRegistrationView _view;

        public RegistrationPresenter(IRegistrationView view)
        {
            _view = view;
        }

        public IRegistrationView GetView()
        {
            return _view;
        }
    }
}
