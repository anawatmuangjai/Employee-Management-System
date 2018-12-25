using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.SkillType
{
    public class SkillTypeViewModel
    {
        public IEnumerable<SkillTypeModel> SkillTypes { get; set; }
    }
}