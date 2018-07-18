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
    public partial class JobTitleView : UserControl, IJobTitleView
    {
        public JobTitleView()
        {
            InitializeComponent();
        }

        public int JobId { get; set; }

        public string JobTitle
        {
            get => JobTitleTextBox.Text.Trim();
            set => JobTitleTextBox.Text = value;
        }

        public string JobDescription
        {
            get => JobDescriptionTextBox.Text.Trim();
            set => JobDescriptionTextBox.Text = value;
        }

        public JobModel SelectedJob { get; set; }

        public IList<JobModel> Jobs
        {
            set
            {
                var jobs = value;
                JobTitleGridView.DataSource = jobs;
            }
        }

        public JobTitlePresenter Presenter { private get; set; }

        public string Filter
        {
            get => SearchToolStripTextBox.Text.Trim();
            set => SearchToolStripTextBox.Text = value;
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
            DetailPanel.Enabled = true;
            JobTitleTextBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedJob = (JobModel)JobTitleGridView.CurrentRow.DataBoundItem;

            if (SelectedJob == null)
                return;

            JobId = SelectedJob.JobId;
            JobTitle = SelectedJob.JobTitle;
            JobDescription = SelectedJob.JobDescription;

            DetailPanel.Enabled = true;
            JobTitleTextBox.Select();
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedJob == null)
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.Save();
            Presenter.ViewAll();
            Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            JobId = 0;
            JobTitle = string.Empty;
            JobDescription = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
