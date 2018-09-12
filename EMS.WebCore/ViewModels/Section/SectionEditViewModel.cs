using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Section
{
    public class SectionEditViewModel
    {
        public int SectionId { get; set; }

        public int DepartmentId { get; set; }

        [Required, StringLength(50)]
        public string SectionName { get; set; }

        [Required, StringLength(10)]
        public string SectionCode { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
