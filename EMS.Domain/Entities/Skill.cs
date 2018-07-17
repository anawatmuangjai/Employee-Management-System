using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            EmployeeSkill = new HashSet<EmployeeSkill>();
            JobFunctionSkill = new HashSet<JobFunctionSkill>();
        }

        public int SkillId { get; set; }
        public int SkillGroupId { get; set; }
        public string SkillName { get; set; }
        public DateTime ChangedDate { get; set; }

        public SkillGroup SkillGroup { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkill { get; set; }
        public ICollection<JobFunctionSkill> JobFunctionSkill { get; set; }
    }
}
