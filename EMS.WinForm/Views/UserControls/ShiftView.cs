﻿using System;
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
using EMS.ApplicationCore.Models;

namespace EMS.WinForm.Views.UserControls
{
    public partial class ShiftView : UserControl, IShiftView
    {
        public ShiftView()
        {
            InitializeComponent();
        }

        public byte ShiftId { get; set; }

        public string ShiftName
        {
            get => ShiftNameTextBox.Text.Trim();
            set => ShiftNameTextBox.Text = value;
        }

        public TimeSpan StartTime
        {
            get
            {
                var dateTime = StartTimePicker.Value;
                return new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
            }
        }

        public TimeSpan EndTime
        {
            get
            {
                var dateTime = EndTimePicker.Value;
                return new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
            }
        }

        public ShiftModel SelectedShift { get; set; }

        public IList<ShiftModel> Shifts
        {
            set
            {
                var shifts = value;
                ShiftGridView.DataSource = shifts;
            }
        }

        public ShiftPresenter Presenter { private get; set; }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
            DetailPanel.Enabled = true;
            ShiftNameTextBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedShift = (ShiftModel)ShiftGridView.CurrentRow.DataBoundItem;

            if (SelectedShift == null)
                return;

            ShiftId = SelectedShift.ShiftId;
            ShiftName = SelectedShift.ShiftName;

            DetailPanel.Enabled = true;
            ShiftNameTextBox.Select();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedShift = (ShiftModel)ShiftGridView.CurrentRow.DataBoundItem;

            if (SelectedShift == null)
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
            ShiftId = 0;
            ShiftName = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
