using EMS.ApplicationCore.Models;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Section
{
    public class SectionViewModel
    {
        public IEnumerable<SectionModel> Sections { get; set; }
    }
}