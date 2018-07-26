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
    public partial class EducationMajorView : UserControl, IEducationMajorView
    {
        public EducationMajorView()
        {
            InitializeComponent();
        }

        public int MajorId { get; set; }

        public int DegreeId { get; set; }

        public string MajorName { get; set; }

        public string MajorNameThai { get; set; }

        public EducationMajorModel SelectedMajor { get; set; }

        public IList<EducationDegreeModel> EducationDegrees
        {
            set
            {
                var degrees = value;
                DegreeComboBox.DataSource = degrees;
                DegreeComboBox.DisplayMember = "DegreeName";
                DegreeComboBox.ValueMember = "DegreeID";
            }
        }

        public IList<EducationMajorModel> EducationMajors
        {
            set
            {
                var majors = value;
                EducationMajorGridView.DataSource = majors;
            }
        }

        public EducationMajorPresenter Presenter { private get; set; }

        private async void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();

            Cursor = Cursors.WaitCursor;
            await Presenter.GetDegreeAsync();
            Cursor = Cursors.Default;

            DetailPanel.Enabled = true;
            DegreeComboBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedMajor = (EducationMajorModel)EducationMajorGridView.CurrentRow.DataBoundItem;

            if (SelectedMajor == null)
                return;

            MajorId = SelectedMajor.MajorId;
            DegreeId = SelectedMajor.DegreeId;
            MajorName = SelectedMajor.MarjorName;
            MajorNameThai = SelectedMajor.MajorNameThai;

            DetailPanel.Enabled = true;
            DegreeComboBox.Select();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedMajor = (EducationMajorModel)EducationMajorGridView.CurrentRow.DataBoundItem;

            if (SelectedMajor == null)
                return;

            var dialogResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;
            await Presenter.DeleteAsync();
            Cursor = Cursors.Default;
        }

        private async void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await Presenter.ViewAllAsync();
            Cursor = Cursors.Default;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await Presenter.SaveAsync();
            Cursor = Cursors.Default;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            MajorId = 0;
            DegreeId = 0;
            MajorName = string.Empty;
            MajorNameThai = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
