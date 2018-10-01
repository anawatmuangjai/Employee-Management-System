using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterSkillType : BaseEntity
    {
        public MasterSkillType()
        {
            MasterSkill = new HashSet<MasterSkill>();
        }

        public int SkillTypeId { get; set; }
        public string SkillTypeName { get; set; }

        public ICollection<MasterSkill> MasterSkill { get; set; }
    }
}
