using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterJobFunction : BaseEntity
    {
        public int JobFunctionId { get; set; }
        public int JobTitleId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }

        public MasterJobTitle JobTitle { get; set; }
    }
}
