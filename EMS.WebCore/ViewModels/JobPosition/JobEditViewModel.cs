using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
