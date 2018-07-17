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
    public partial class JobTitleView : UserControl, IJobTitleView
    {
        public JobTitleView()
        {
            InitializeComponent();
        }

        public int JobId { get; set; }

        public string JobTitle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string JobDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MasterJob SelectedJob { get; set; }

        public IList<MasterJob> Jobs
        {
            set
            {
                var jobs = value;
                JobTitleGridView.DataSource = jobs;
            }
        }

        public JobTitlePresenter Presenter { private get; set; }

    }
}
