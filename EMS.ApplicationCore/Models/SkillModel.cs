using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class SkillModel
    {
        public int SkillId { get; set; }
        public int SkillGroupId { get; set; }
        public int SkillTypeId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }

        public SkillGroupModel SkillGroup { get; set; }
        public SkillTypeModel SkillType { get; set; }
    }
}
