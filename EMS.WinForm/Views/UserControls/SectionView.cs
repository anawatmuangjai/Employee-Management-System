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
using EMS.Domain.Entities;
using EMS.ApplicationCore.Models;

namespace EMS.WinForm.Views.UserControls
{
    public partial class SectionView : UserControl, ISectionView
    {
        public SectionView()
        {
            InitializeComponent();
        }

        public SectionPresenter Presenter { private get; set; }

        public int SectionID { get; set; }

        public int DepartmentID { get; set; }

        public string SectionName { get => SectionNameTextBox.Text.Trim(); set => SectionNameTextBox.Text = value; }

        public string SectionCode { get => SectionCodeTextBox.Text.Trim(); set => SectionCodeTextBox.Text = value; }

        public string Filter { get => SearchToolStripTextBox.Text.Trim(); set => SearchToolStripTextBox.Text = value; }

        public SectionModel SelectedSection { get; set; }

        public DepartmentModel SelectedDepartment { get; set; }

        public IList<SectionModel> Sections
        {
            set
            {
                var sections = value;
                SectionGridView.DataSource = sections;
            }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                var departments = value;
                DepartmentComboBox.DataSource = departments;
                DepartmentComboBox.DisplayMember = "DepartmentName";
                DepartmentComboBox.ValueMember = "DepartmentID";
            }
        }

        private async void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Clear();
            await Presenter.GetDepartmentsAsync();

            DepartmentComboBox.Select();
            DetailPanel.Enabled = true;

            Cursor = Cursors.Default;
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedSection = (SectionModel)SectionGridView.CurrentRow.DataBoundItem;

            if (SelectedSection == null)
                return;

            SectionID = SelectedSection.SectionId;
            DepartmentID = SelectedSection.DepartmentId;
            SectionName = SelectedSection.SectionName;
            SectionCode = SelectedSection.SectionCode;

            DetailPanel.Enabled = true;
            DepartmentComboBox.Select();
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private async void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            await Presenter.SearchAsync();
        }

        private async void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            await Presenter.ViewAllAsync();

            Cursor = Cursors.Default;
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            await Presenter.SaveAsync();
            await Presenter.ViewAllAsync();
            Clear();

            Cursor = Cursors.Default;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentComboBox.Items.Count == 0)
                return;

            var department = DepartmentComboBox.SelectedItem as DepartmentModel;

            SelectedDepartment = department;
            DepartmentID = department.DepartmentId;
        }

        private void Clear()
        {
            SectionID = 0;
            DepartmentID = 0;
            SectionName = string.Empty;
            SectionCode = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
