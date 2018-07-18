using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class SkillGroup : BaseEntity
    {
        public SkillGroup()
        {
            Skill = new HashSet<Skill>();
        }

        public int SkillGroupId { get; set; }
        public string SkillGroupName { get; set; }

        public ICollection<Skill> Skill { get; set; }
    }
}
