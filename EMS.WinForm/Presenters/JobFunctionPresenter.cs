using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class JobFunctionPresenter : IJobFunctionPresenter
    {
        private readonly IJobFunctionView _view;

        public JobFunctionPresenter(IJobFunctionView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public IJobFunctionView GetView()
        {
            return _view;
        }
    }
}
