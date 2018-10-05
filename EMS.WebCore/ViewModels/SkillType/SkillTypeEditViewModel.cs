using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.SkillType
{
    public class SkillTypeEditViewModel
    {
        public int SkillTypeId { get; set; }

        [Required]
        public string SkillTypeName { get; set; }

        public string Description { get; set; }
    }
}
