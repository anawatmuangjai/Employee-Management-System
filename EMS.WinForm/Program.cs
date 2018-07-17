using EMS.WinForm.IoCContainer;
using EMS.WinForm.Presenters;
using EMS.WinForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IoC.Initialize(new IoCConfiguration());
            Application.Run((Form)IoC.Get<LoginPresenter>().GetView());
        }
    }
}
