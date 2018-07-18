using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class JobFunctionSkill : BaseEntity
    {
        public int JobFunctionId { get; set; }
        public int SkillId { get; set; }
        public bool? Require { get; set; }
        public DateTime ChangedDate { get; set; }

        public MasterJobFunction JobFunction { get; set; }
        public Skill Skill { get; set; }
    }
}
