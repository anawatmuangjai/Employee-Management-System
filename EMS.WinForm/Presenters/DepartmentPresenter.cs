using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class DepartmentPresenter : IDepartmentPresenter
    {
        private readonly IDepartmentView _view;

        public DepartmentPresenter(IDepartmentView view)
        {
            _view = view;
        }

        public IDepartmentView GetView()
        {
            return _view;
        }
    }
}
