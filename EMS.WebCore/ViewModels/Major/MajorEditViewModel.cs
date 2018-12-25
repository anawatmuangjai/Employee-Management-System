using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.Major
{
    public class MajorEditViewModel
    {
        public int MajorId { get; set; }

        public int DegreeId { get; set; }

        [Required]
        public string MarjorName { get; set; }

        [Required]
        public string MajorNameThai { get; set; }
    }
}