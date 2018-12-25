﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.EmployeeSkill
{
    public class EmployeeSkillEditViewModel
    {
        public string EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int SkillGroupId { get; set; }
        public int SkillTypeId { get; set; }
        public int SkillLevel { get; set; }

        public IEnumerable<SelectListItem> SkillGroups { get; set; }
        public IEnumerable<SelectListItem> SkillTypes { get; set; }
    }
}