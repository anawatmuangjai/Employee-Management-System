using EMS.WinForm.IoCContainer;
using EMS.WinForm.Presenters;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS.WinForm.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();

            MenuTreeView.ExpandAll();
        }

        public void ShowView()
        {
            this.Show();
        }

        private void DisplayView(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(userControl);
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MenuTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                var tagId = e.Node.Tag.ToString();

                switch (tagId)
                {
                    case "1":
                        DisplayView((UserControl)IoC.Get<RegistrationPresenter>().GetView());
                        break;
                    case "6":
                        DisplayView((UserControl)IoC.Get<DepartmentPresenter>().GetView());
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
