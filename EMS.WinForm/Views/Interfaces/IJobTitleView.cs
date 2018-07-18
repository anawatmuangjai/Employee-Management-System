using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IJobTitleView
    {
        int JobId { get; set; }
        string JobTitle { get; set; }
        string JobDescription { get; set; }
        string Filter { get; set; }
        JobModel SelectedJob { get; set; }
        IList<JobModel> Jobs { set; }
        JobTitlePresenter Presenter { set; }
    }
}
