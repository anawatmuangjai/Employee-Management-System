using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.JobFunction
{
    public class JobFunctionViewModel
    {
        public IEnumerable<JobFunctionModel> JobFunctions { get; set; }
    }
}