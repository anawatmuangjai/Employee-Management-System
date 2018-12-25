using EMS.WebCore.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IProfileViewModelService
    {
        Task<ProfileViewModel> GetProfile(string employeeId);

        Task<ProfileEditViewModel> EditProfile(string employeeId);

        Task<PersonalInfoViewModel> GetPersonalInfo(string employeeId);

        Task<EmployeeInfoViewModel> GetEmployeeInfo(string employeeId);

        Task<AddressInfoViewModel> GetAddressInfo(string employeeId);

        Task<EmployeeImageViewModel> GetEmployeeImage(string employeeId);

        Task UpdatePersonalInfo(PersonalInfoViewModel model);

        Task UpdateEmployeeInfo(EmployeeInfoViewModel model);

        Task UpdateAddressInfo(AddressInfoViewModel model);

        Task UpdateEmployeeImage(EmployeeImageViewModel model);

        Task UpdateProfile(ProfileEditViewModel model);

        Task<IEnumerable<SelectListItem>> GetSectionsByDepartmentId(int departmentId);

        Task<IEnumerable<SelectListItem>> GetJobFunctionBySectionId(int sectionId);

        Task<IEnumerable<SelectListItem>> GetBusStationByRouteId(int routeId);
    }
}