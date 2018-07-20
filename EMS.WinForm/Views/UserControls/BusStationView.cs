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
    public partial class BusStationView : UserControl, IBusStationView
    {
        public BusStationView()
        {
            InitializeComponent();
        }

        public int BusStationId { get; set; }

        public string BusStationName
        {
            get => BusStationNameTextBox.Text.Trim();
            set => BusStationNameTextBox.Text = value;
        }

        public string BusStationRoute
        {
            get => BusStationRouteTextBox.Text.Trim();
            set => BusStationRouteTextBox.Text = value;
        }

        public string Filter
        {
            get => SearchToolStripTextBox.Text.Trim();
            set => SearchToolStripTextBox.Text = value;
        }

        public BusStationModel SelectedBusStation { get; set; }

        public IList<BusStationModel> BusStations
        {
            set
            {
                var busStations = value;
                BusStationGridView.DataSource = busStations;
            }
        }

        public BusStationPresenter Presenter { private get; set; }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Clear();
            DetailPanel.Enabled = true;
            BusStationNameTextBox.Select();
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedBusStation = (BusStationModel)BusStationGridView.CurrentRow.DataBoundItem;

            if (SelectedBusStation == null)
                return;

            BusStationId = SelectedBusStation.BusStationId;
            BusStationName = SelectedBusStation.BusStationName;
            BusStationRoute = SelectedBusStation.BusStationRoute;

            DetailPanel.Enabled = true;
            BusStationNameTextBox.Select();
        }

        private async void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            SelectedBusStation = (BusStationModel)BusStationGridView.CurrentRow.DataBoundItem;

            if (SelectedBusStation == null)
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
            Clear();
        }

        private async void ViewToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await Presenter.ViewAllAsync();
            Cursor = Cursors.Default;
            Clear();
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
            BusStationId = 0;
            BusStationName = string.Empty;
            BusStationRoute = string.Empty;
            DetailPanel.Enabled = false;
        }
    }
}
