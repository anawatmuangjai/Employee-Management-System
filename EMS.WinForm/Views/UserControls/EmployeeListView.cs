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
using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;

namespace EMS.WinForm.Views.UserControls
{
    public partial class EmployeeListView : UserControl, IEmployeeListView
    {
        public EmployeeListView()
        {
            InitializeComponent();
        }

        public IList<EmployeeListModel> Employees
        {
            set
            {
                var employees = value;

                EmployeeGridView.Rows.Clear();

                foreach (var e in employees)
                {
                    EmployeeGridView.Rows.Add(
                        e.Images,
                        e.EmployeeType,
                        e.GlobalId,
                        e.Title,
                        e.FirstName,
                        e.LastName,
                        e.FirstNameThai,
                        e.LastNameThai,
                        e.Gender,
                        e.JobTitle,
                        e.DepartmentName,
                        e.HireDate,
                        e.ChangedDate);
                }
            }
        }

        public EmployeeListPresenter Presenter {  private get; set; }

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private async void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await Presenter.ViewAllAsync();
            Cursor = Cursors.Default;
        }
    }
}
