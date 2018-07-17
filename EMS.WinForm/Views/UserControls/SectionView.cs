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

        public MasterSection SelectedSection { get; set; }

        public MasterDepartment SelectedDepartment { get; set; }

        public IList<MasterSection> Sections
        {
            set
            {
                var sections = value;
                SectionGridView.DataSource = sections;
            }
        }

        public IList<MasterDepartment> Departments
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
            Clear();

            await Presenter.GetDepartments();

            DepartmentComboBox.Select();
            SectionDetailPanel.Enabled = true;
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedSection = (MasterSection)SectionGridView.CurrentRow.DataBoundItem;

            if (SelectedSection == null)
                return;

            SectionID = SelectedSection.SectionId;
            DepartmentID = SelectedSection.DepartmentId;
            SectionName = SelectedSection.SectionName;
            SectionCode = SelectedSection.SectionCode;

            SectionDetailPanel.Enabled = true;
            DepartmentComboBox.Select();
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            Presenter.Search();
        }

        private async void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            await Presenter.ViewAll();
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            await Presenter.Save();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentComboBox.Items.Count == 0)
                return;

            var department = DepartmentComboBox.SelectedItem as MasterDepartment;

            SelectedDepartment = department;
            DepartmentID = department.DepartmentId;
        }

        private void Clear()
        {
            SectionID = 0;
            DepartmentID = 0;
            SectionName = string.Empty;
            SectionCode = string.Empty;
            SectionDetailPanel.Enabled = false;
        }
    }
}
