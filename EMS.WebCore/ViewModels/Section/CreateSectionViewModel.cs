using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Section
{
    public class CreateSectionViewModel
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string SectionName { get; set; }

        [Required]
        public string SectionCode { get; set; }
    }
}
