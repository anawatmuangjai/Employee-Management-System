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

        public SectionDto SelectedSection { get; set; }

        public DepartmentDto SelectedDepartment { get; set; }

        public IList<SectionDto> Sections
        {
            set
            {
                var sections = value;
                SectionGridView.DataSource = sections;
            }
        }

        public IList<DepartmentDto> Departments
        {
            set
            {
                var departments = value;
                DepartmentComboBox.DataSource = departments;
                DepartmentComboBox.DisplayMember = "DepartmentName";
                DepartmentComboBox.ValueMember = "DepartmentID";
            }
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();

            Presenter.GetDepartments();

            DepartmentComboBox.Select();
            SectionDetailPanel.Enabled = true;
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedSection = (SectionDto)SectionGridView.CurrentRow.DataBoundItem;

            if (SelectedSection == null)
                return;

            SectionID = SelectedSection.SectionID;
            DepartmentID = SelectedSection.DepartmentID;
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
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentComboBox.Items.Count == 0)
                return;

            var department = DepartmentComboBox.SelectedItem as DepartmentDto;

            SelectedDepartment = department;
            DepartmentID = department.DepartmentID;
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
