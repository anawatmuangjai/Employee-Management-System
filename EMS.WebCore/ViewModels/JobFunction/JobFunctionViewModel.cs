using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.JobFunction
{
    public class JobFunctionViewModel
    {
        public IEnumerable<JobFunctionModel> JobFunctions { get; set; }
    }
}
