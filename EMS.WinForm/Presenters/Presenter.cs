using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public abstract class Presenter<T> where T : IView
    {
        protected T View { get; private set; }

        protected Presenter(T view)
        {
            View = view;
        }

        public T GetView()
        {
            return View;
        }
    }
}
