using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class JobFunctionModel
    {
        public int JobFunctionId { get; set; }
        public int SectionId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionCode { get; set; }

        public SectionModel Section { get; set; }
    }
}
