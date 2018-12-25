using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Skill
{
    public class SkillViewModel
    {
        public IEnumerable<SkillModel> Skills { get; set; }
    }
}