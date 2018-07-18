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
    public partial class RegistrationView : UserControl, IEmployeeView
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        public EmployeePresenter Presenter { private get; set; }
        public int EmployeeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GlobalId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CardId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EmployeeType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstNameThai { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastNameThai { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AvailableFlag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EmailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime HireDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ChangedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
