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
using EMS.Core.Dtos;

namespace EMS.WinForm.Views.UserControls
{
    public partial class DepartmentView : UserControl, IDepartmentView
    {
        public DepartmentView()
        {
            InitializeComponent();
        }

        public int DepartmentId { get; set; }

        public string DepartmentName
        {
            get => DepartmentNameTextBox.Text.Trim();
            set => DepartmentNameTextBox.Text = value;
        }

        public string DepartmentCode
        {
            get => DepartmentCodeTextBox.Text.Trim();
            set => DepartmentCodeTextBox.Text = value;
        }

        public string DepartmentGroup
        {
            get => DepartmentGroupTextBox.Text.Trim();
            set => DepartmentGroupTextBox.Text = value;
        }

        public string Filter
        {
            get => SearchToolStripTextBox.Text.Trim();
            set => SearchToolStripTextBox.Text = value;
        }

        public DepartmentDto SelectedDepartment { get; set; }

        public IList<DepartmentDto> Departments
        {
            set
            {
                var departments = value;
                DepartmentGridView.DataSource = departments;
            }
        }

        public DepartmentPresenter Presenter { private get; set; }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
            DetailPanel.Enabled = true;
            DepartmentNameTextBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedDepartment = (DepartmentDto)DepartmentGridView.CurrentRow.DataBoundItem;

            if (SelectedDepartment == null)
                return;

            DepartmentId = SelectedDepartment.DepartmentID;
            DepartmentName = SelectedDepartment.DepartmentName;
            DepartmentCode = SelectedDepartment.DepartmentCode;
            DepartmentGroup = SelectedDepartment.DepartmentGroup;

            DetailPanel.Enabled = true;
            DepartmentNameTextBox.Select();
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedDepartment = (DepartmentDto)DepartmentGridView.CurrentRow.DataBoundItem;

            if (SelectedDepartment == null)
                return;

            var dialogResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            Presenter.Delete();
        }

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            Presenter.Search();
        }

        private void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            Presenter.ViewAll();
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.Save();
            Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            DepartmentId = 0;
            DepartmentName = string.Empty;
            DepartmentCode = string.Empty;
            DepartmentGroup = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
