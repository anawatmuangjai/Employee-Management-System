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

        public MasterJobFunction SelectedJobFunction { get; set; }

        public IList<MasterJobFunction> JobJobFunctions
        {
            set
            {
                var jobFunctions = value;
                JobFunctionGridView.DataSource = jobFunctions;
            }
        }

        public JobFunctionPresenter Presenter { private get; set; }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void ViewToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
