using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.SkillGroup
{
    public class SkillGroupViewModel
    {
        public IEnumerable<SkillGroupModel> SkillGroups { get; set; }
    }
}