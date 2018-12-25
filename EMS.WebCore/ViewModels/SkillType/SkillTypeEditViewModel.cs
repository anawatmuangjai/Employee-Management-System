using System.ComponentModel.DataAnnotations;

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