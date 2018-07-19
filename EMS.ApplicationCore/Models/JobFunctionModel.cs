using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class JobFunctionModel
    {
        public int JobFunctionId { get; set; }
        public int JobId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
    }
}
