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
    public partial class EducationDegreeView : UserControl, IEducationDegreeView
    {
        public EducationDegreeView()
        {
            InitializeComponent();
        }

        public int DegreeId { get; set; }

        public string DegreeName
        {
            get => DegreeNameTextBox.Text.Trim();
            set => DegreeNameTextBox.Text = value;
        }

        public string DegreeNameThai
        {
            get => DegreeNameThaiTextBox.Text.Trim();
            set => DegreeNameThaiTextBox.Text = value;
        }

        public EducationDegreeModel SelectedDegree { get; set; }

        public IList<EducationDegreeModel> EducationDegrees
        {
            set
            {
                var degrees = value;
                EducationDegreeGridView.DataSource = degrees;
            }
        }

        public EducationDegreePresenter Presenter { private get; set; }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
            DetailPanel.Enabled = true;
            DegreeNameTextBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedDegree = (EducationDegreeModel)EducationDegreeGridView.CurrentRow.DataBoundItem;

            if (SelectedDegree == null)
                return;

            DegreeId = SelectedDegree.DegreeId;
            DegreeName = SelectedDegree.DegreeName;
            DegreeNameThai = SelectedDegree.DegreeNameThai;

            DetailPanel.Enabled = true;
            DegreeNameTextBox.Select();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedDegree = (EducationDegreeModel)EducationDegreeGridView.CurrentRow.DataBoundItem;

            if (SelectedDegree == null)
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
            DegreeId = 0;
            DegreeName = string.Empty;
            DegreeNameThai = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
