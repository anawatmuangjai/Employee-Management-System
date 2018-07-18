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
    public partial class EmployeeLevelView : UserControl, IEmployeeLevelView
    {
        public EmployeeLevelView()
        {
            InitializeComponent();
        }

        public int LevelId { get; set; }

        public string LevelName
        {
            get => LevelNameTextBox.Text.Trim();
            set => LevelNameTextBox.Text = value;
        }

        public string LevelCode
        {
            get => LevelCodeTextBox.Text.Trim();
            set => LevelCodeTextBox.Text = value;
        }

        public EmployeeLevelModel SelectedLevel { get; set; }

        public IList<EmployeeLevelModel> Levels
        {
            set
            {
                var levels = value;
                LevelGridView.DataSource = levels;
            }
        }

        public EmployeeLevelPresenter Presenter {  private get; set; }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
            DetailPanel.Enabled = true;
            LevelNameTextBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedLevel = (EmployeeLevelModel)LevelGridView.CurrentRow.DataBoundItem;

            if (SelectedLevel == null)
                return;

            LevelId = SelectedLevel.LevelId;
            LevelName = SelectedLevel.LevelName;
            LevelCode = SelectedLevel.LevelCode;

            DetailPanel.Enabled = true;
            LevelNameTextBox.Select();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedLevel = (EmployeeLevelModel)LevelGridView.CurrentRow.DataBoundItem;

            if (SelectedLevel == null)
                return;

            var dialogResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            await Presenter.DeleteAsync();
        }

        private async void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            await Presenter.ViewAllAsync();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            await Presenter.SaveAsync();
            await Presenter.ViewAllAsync();
            Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            LevelId = 0;
            LevelName = string.Empty;
            LevelCode = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
