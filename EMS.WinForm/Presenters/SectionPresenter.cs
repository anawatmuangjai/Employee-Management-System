using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class SectionPresenter : ISectionPresenter
    {
        private readonly ISectionView _view;

        public SectionPresenter(ISectionView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public ISectionView GetView()
        {
            return _view;
        }
    }
}
