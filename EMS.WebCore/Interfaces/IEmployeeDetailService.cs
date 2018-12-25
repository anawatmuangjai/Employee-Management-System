using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IEmployeeDetailService
    {
        Task<IEnumerable<SelectListItem>> GetDepartments();

        Task<IEnumerable<SelectListItem>> GetSections();

        Task<IEnumerable<SelectListItem>> GetSectionsByDepartmentId(int departmentId);

        Task<IEnumerable<SelectListItem>> GetJobFunctions();

        Task<IEnumerable<SelectListItem>> GetJobFunctionsBySectionId(int sectionId);

        Task<IEnumerable<SelectListItem>> GetPositions();

        Task<IEnumerable<SelectListItem>> GetShifts();

        Task<IEnumerable<SelectListItem>> GetLevels();

        Task<IEnumerable<SelectListItem>> GetRoutes();

        Task<IEnumerable<SelectListItem>> GetBusStations();

        Task<IEnumerable<SelectListItem>> GetGetBusStationsByRouteId(int routeId);

        Task<IEnumerable<SelectListItem>> GetSkillGroups();

        Task<IEnumerable<SelectListItem>> GetSkillTypes();

        Task<IEnumerable<SelectListItem>> GetSkills(int skillGropId, int skillTypeId);
    }
}