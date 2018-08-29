using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.JobPosition
{
    public class JobViewModel
    {
        public IEnumerable<JobPositionModel> JobTitles { get; set; }
    }
}
