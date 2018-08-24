using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.Department
{
    public class DepartmentEditViewModel
    {
        public int DepartmentId { get; set; }

        [Required, StringLength(50)]
        public string DepartmentName { get; set; }

        [Required, StringLength(10)]
        public string DepartmentCode { get; set; }

        [Required, StringLength(50)]
        public string DepartmentGroup { get; set; }
    }
}
