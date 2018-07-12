using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class JobTitlePresenter : IJobTitlePresenter
    {
        private readonly IJobTitleView _view;

        public JobTitlePresenter(IJobTitleView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public IJobTitleView GetView()
        {
            return _view;
        }
    }
}
