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
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            UsernameTextBox.Focus();
            UsernameTextBox.Select();
        }

        public string Username
        {
            get => UsernameTextBox.Text.Trim();
            set => UsernameTextBox.Text = value;
        }

        public string Password
        {
            get => PasswordTextBox.Text.Trim();
            set => PasswordTextBox.Text = value;
        }

        public string Message
        {
            get => MessageLabel.Text;
            set => MessageLabel.Text = value;
        }

        public LoginPresenter Presenter { private get; set; }

        public void ShowView()
        {
            this.ShowDialog();
        }

        public void ShowMainView()
        {
            IoC.Get<MainPresenter>().ShowView();
            this.Hide();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Presenter.Login();
        }
    }
}
