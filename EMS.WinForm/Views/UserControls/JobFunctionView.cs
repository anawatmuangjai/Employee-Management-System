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
    public partial class JobFunctionView : UserControl, IJobFunctionView
    {
        public JobFunctionView()
        {
            InitializeComponent();
        }

        public int JobFunctionId { get; set; }

        public int JobId { get; set; }

        public string FunctionName
        {
            get => FunctionNameTextBox.Text.Trim();
            set => FunctionNameTextBox.Text = value;
        }

        public string FunctionDescription
        {
            get => DescriptionTextBox.Text.Trim();
            set => DescriptionTextBox.Text = value;
        }

        public string Filter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public JobFunctionModel SelectedJobFunction { get; set; }

        public IList<JobModel> JobModels
        {
            set
            {
                var jobTitles = value;
                JobComboBox.DataSource = jobTitles;
                JobComboBox.DisplayMember = "JobTitle";
                JobComboBox.ValueMember = "JobId";
                JobComboBox.SelectedIndex = -1;
            }
        }

        public IList<JobFunctionModel> JobJobFunctions
        {
            set
            {
                var jobFunctions = value;
                JobFunctionGridView.DataSource = jobFunctions;
            }
        }

        public JobFunctionPresenter Presenter { private get; set; }

        private async void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();

            Cursor = Cursors.WaitCursor;
            await Presenter.GetJobTitleAsync();
            Cursor = Cursors.Default;

            DetailPanel.Enabled = true;
            JobComboBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedJobFunction = (JobFunctionModel)JobFunctionGridView.CurrentRow.DataBoundItem;

            if (SelectedJobFunction == null)
                return;

            JobFunctionId = SelectedJobFunction.JobFunctionId;
            JobId = SelectedJobFunction.JobId;
            FunctionName = SelectedJobFunction.FunctionName;
            FunctionDescription = SelectedJobFunction.FunctionDescription;

            DetailPanel.Enabled = true;
            JobComboBox.Select();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedJobFunction == null)
                return;

            var dialogResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;
            await Presenter.DeleteAsync();
            Cursor = Cursors.Default;
        }

        private async void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await Presenter.SearchAsync();
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
            await Presenter.ViewAllAsync();
            Cursor = Cursors.Default;
            Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            JobFunctionId = 0;
            JobId = 0;
            FunctionName = string.Empty;
            FunctionDescription = string.Empty;
            DetailPanel.Enabled = false;
        }

        private void JobComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JobComboBox.SelectedIndex < 0)
                return;

            var job = JobComboBox.SelectedItem as JobModel;
            JobId = job.JobId;
        }
    }
}
