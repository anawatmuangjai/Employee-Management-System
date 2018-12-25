using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Degree
{
    public class DegreeViewModel
    {
        public IEnumerable<EducationDegreeModel> Degrees { get; set; }
    }
}