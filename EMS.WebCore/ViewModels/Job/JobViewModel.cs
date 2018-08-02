using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Job
{
    public class JobViewModel
    {
        public IEnumerable<JobTitleModel> JobTitles { get; set; }
        public IEnumerable<JobFunctionModel> JobFunctions { get; set; }
    }
}
