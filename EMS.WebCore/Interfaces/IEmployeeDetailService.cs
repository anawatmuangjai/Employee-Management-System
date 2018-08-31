using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IEmployeeDetailService
    {
        Task<IEnumerable<SelectListItem>> GetDepartments();
        Task<IEnumerable<SelectListItem>> GetSections();
        Task<IEnumerable<SelectListItem>> GetShifts();
        Task<IEnumerable<SelectListItem>> GetPositions();
        Task<IEnumerable<SelectListItem>> GetJobFunctions();
        Task<IEnumerable<SelectListItem>> GetLevels();
        Task<IEnumerable<SelectListItem>> GetBusStations();
    }
}
