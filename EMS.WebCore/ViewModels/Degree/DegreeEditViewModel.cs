using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
