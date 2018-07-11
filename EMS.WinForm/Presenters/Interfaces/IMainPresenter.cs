using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters.Interfaces
{
    public interface IMainPresenter
    {
        IMainView GetView();
        void ShowView();
    }
}
