using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.JobPosition
{
    public class JobEditViewModel
    {
        public int PositionId { get; set; }

        [Required, StringLength(50)]
        public string PositionName { get; set; }

        public string PositionCode { get; set; }
    }
}