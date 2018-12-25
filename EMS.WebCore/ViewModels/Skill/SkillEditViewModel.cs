using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Skill
{
    public class SkillEditViewModel
    {
        public int SkillId { get; set; }
        public int SkillGroupId { get; set; }
        public int SkillTypeId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }

        public IEnumerable<SelectListItem> SkillGroups { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }
    }
}