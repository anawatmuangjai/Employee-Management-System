using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class EmployeeDetailPresenter : IEmployeeDetailPresenter
    {
        private readonly IEmployeeDetailView _view;

        public EmployeeDetailPresenter(IEmployeeDetailView view)
        {
            _view = view;
        }

        public IEmployeeDetailView GetView()
        {
            return _view;
        }
    }
}
