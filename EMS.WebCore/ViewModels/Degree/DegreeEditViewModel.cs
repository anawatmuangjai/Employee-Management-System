using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.Degree
{
    public class DegreeEditViewModel
    {
        public int DegreeId { get; set; }

        [Required]
        public string DegreeName { get; set; }

        [Required]
        public string DegreeNameThai { get; set; }
    }
}