using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Job
{
    public class JobEditViewModel
    {
        public int JobTitleId { get; set; }

        [Required, StringLength(50)]
        public string JobTitle { get; set; }

        public string JobDescription { get; set; }
    }
}
