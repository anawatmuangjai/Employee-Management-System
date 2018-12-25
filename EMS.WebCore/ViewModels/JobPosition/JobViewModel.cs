using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.JobPosition
{
    public class JobViewModel
    {
        public IEnumerable<JobPositionModel> JobTitles { get; set; }
    }
}