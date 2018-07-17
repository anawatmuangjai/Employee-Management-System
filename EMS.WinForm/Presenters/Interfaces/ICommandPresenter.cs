using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters.Interfaces
{
    public interface ICommandPresenter
    {
        void ViewAll();
        void Search();
        void Save();
        void Delete();
    }
}
