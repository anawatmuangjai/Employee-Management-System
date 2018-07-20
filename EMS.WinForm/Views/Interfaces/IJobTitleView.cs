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
        JobTitleModel SelectedJob { get; set; }
        IList<JobTitleModel> Jobs { set; }
        JobTitlePresenter Presenter { set; }
    }
}
