using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS.WinForm.Views.Interfaces;
using EMS.WinForm.Presenters;

namespace EMS.WinForm.Views.UserControls
{
    public partial class JobFunctionView : UserControl, IJobFunctionView
    {
        public JobFunctionView()
        {
            InitializeComponent();
        }

        public JobFunctionPresenter Presenter { private get; set; }
    }
}
