using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Major
{
    public class MajorViewModel
    {
        public IEnumerable<EducationMajorModel> Majors { get; set; }
    }
}
