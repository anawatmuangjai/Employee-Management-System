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
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public TimeSpan EndTime
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ShiftPresenter Presenter { private get; set; }

    }
}
