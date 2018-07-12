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
    public partial class RegistrationView : UserControl, IRegistrationView
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        public RegistrationPresenter Presenter { private get; set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
