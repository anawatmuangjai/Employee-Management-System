using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterJobFunction : BaseEntity
    {
        public MasterJobFunction()
        {
            JobFunctionSkill = new HashSet<JobFunctionSkill>();
        }

        public int JobFunctionId { get; set; }
        public int JobId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }

        public MasterJob Job { get; set; }
        public ICollection<JobFunctionSkill> JobFunctionSkill { get; set; }
    }
}
