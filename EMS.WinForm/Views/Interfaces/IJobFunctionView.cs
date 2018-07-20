using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IJobFunctionView
    {
        int JobFunctionId { get; set; }
        int JobId { get; set; }
        string FunctionName { get; set; }
        string FunctionDescription { get; set; }
        string Filter { get; set; }
        JobFunctionModel SelectedJobFunction { get; set; }
        IList<JobTitleModel> JobModels { set; }
        IList<JobFunctionModel> JobJobFunctions { set; }
        JobFunctionPresenter  Presenter { set; }
    }
}
