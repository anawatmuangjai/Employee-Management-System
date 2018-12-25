using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Major
{
    public class MajorViewModel
    {
        public IEnumerable<EducationMajorModel> Majors { get; set; }
    }
}