using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.JobFunction
{
    public class JobFunctionEditViewModel
    {
        public int JobFunctionId { get; set; }
        public int JobTitleId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
    }
}
