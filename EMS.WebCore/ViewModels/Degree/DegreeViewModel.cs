using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Degree
{
    public class DegreeViewModel
    {
        public IEnumerable<EducationDegreeModel> Degrees { get; set; }
    }
}
