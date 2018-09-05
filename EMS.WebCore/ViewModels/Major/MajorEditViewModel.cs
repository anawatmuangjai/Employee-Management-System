using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
