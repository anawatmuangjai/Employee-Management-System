using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Level
{
    public class LevelEditViewModel
    {
        public int LevelId { get; set; }

        [Required, StringLength(30)]
        public string LevelName { get; set; }

        [Required, StringLength(10)]
        public string LevelCode { get; set; }
    }
}
