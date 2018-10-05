using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class ProfileViewModelService : IProfileViewModelService
    {
        private readonly IEmployeeDetailService _employeeDetailService;
        private readonly IEmployeeStateService _employeeStateService;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeAddressService _employeeAddressService;
        private readonly IEmployeeImageService _employeeImageService;

        public ProfileViewModelService(
            IEmployeeDetailService employeeDetailService,
            IEmployeeStateService employeeStateService,
            IEmployeeService employeeService,
            IEmployeeAddressService employeeAddressService,
            IEmployeeImageService employeeImageService)
        {
            _employeeDetailService = employeeDetailService;
            _employeeStateService = employeeStateService;
            _employeeService = employeeService;
            _employeeAddressService = employeeAddressService;
            _employeeImageService = employeeImageService;
        }

        public async Task<ProfileViewModel> GetProfile(string employeeId)
        {
            var viewModel = new ProfileViewModel();

            var employee = await _employeeService.GetByEmployeeIdWithDetailAsync(employeeId);

            if (employee != null)
            {
                viewModel.EmployeeId = employee.EmployeeId;
                viewModel.GlobalId = employee.GlobalId;
                viewModel.CardId = employee.CardId;
                viewModel.EmployeeType = employee.EmployeeType;
                viewModel.Title = employee.Title;
                viewModel.TitleThai = employee.TitleThai;
                viewModel.FirstName = employee.FirstName;
                viewModel.LastName = employee.LastName;
                viewModel.FirstNameThai = employee.FirstNameThai;
                viewModel.LastNameThai = employee.LastNameThai;
                viewModel.Gender = employee.Gender;
                viewModel.Age = CalculateAge(employee.BirthDate);
                viewModel.Height = employee.Height;
                viewModel.Hand = employee.Hand;
                viewModel.BirthDate = employee.BirthDate;
                viewModel.HireDate = employee.HireDate;
                viewModel.HireType = employee.HireType;
                viewModel.EmploymentDuration = CalculateDurationOfEmployment(employee.HireDate);

                if (employee.EmployeeState != null)
                {
                    viewModel.DepartmentName = employee.EmployeeState.JobFunction.Section.Department.DepartmentName;
                    viewModel.SectionName = employee.EmployeeState.JobFunction.Section.SectionName;
                    viewModel.ShiftName = employee.EmployeeState.Shift.ShiftName;
                    viewModel.LevelCode = employee.EmployeeState.Level.LevelName;
                    viewModel.PositionName = employee.EmployeeState.Position.PositionName;
                    viewModel.FunctionName = employee.EmployeeState.JobFunction.FunctionName;
                    viewModel.RouteName = employee.EmployeeState.BusStation.Route.RouteName;
                    viewModel.BusStationName = employee.EmployeeState.BusStation.BusStationName;
                    viewModel.JoinDate = employee.EmployeeState.JoinDate;
                }
            }

            var address = await _employeeAddressService.GetByEmployeeId(employeeId);

            if (address != null)
            {
                viewModel.HomeAddress = address.HomeAddress;
                viewModel.City = address.City;
                viewModel.Country = address.Country;
                viewModel.PostalCode = address.PostalCode;
                viewModel.PhoneNumber = address.PhoneNumber;
                viewModel.EmailAddress = address.EmailAddress;
            }

            var image = await _employeeImageService.GetByEmployeeId(employeeId);

            if (image != null)
            {
                var imageBase64Data = Convert.ToBase64String(image.Images);
                viewModel.ProfileImage = string.Format("data:image/png;base64,{0}", imageBase64Data);
            }

            return viewModel;
        }

        public async Task<ProfileEditViewModel> EditProfile(string employeeId)
        {
            var viewModel = new ProfileEditViewModel();

            viewModel.Departments = await _employeeDetailService.GetDepartments();
            viewModel.Shifts = await _employeeDetailService.GetShifts();
            viewModel.JobPosition = await _employeeDetailService.GetPositions();
            viewModel.JobLevels = await _employeeDetailService.GetLevels();
            viewModel.Routes = await _employeeDetailService.GetRoutes();
            viewModel.BusStations = await _employeeDetailService.GetBusStations();

            var employee = await _employeeService.GetByEmployeeIdWithDetailAsync(employeeId);

            if (employee != null)
            {
                viewModel.EmployeeId = employee.EmployeeId;
                viewModel.GlobalId = employee.GlobalId;
                viewModel.CardId = employee.CardId;
                viewModel.Title = employee.Title;
                viewModel.TitleThai = employee.TitleThai;
                viewModel.EmployeeType = employee.EmployeeType;
                viewModel.FirstName = employee.FirstName;
                viewModel.LastName = employee.LastName;
                viewModel.FirstNameThai = employee.FirstNameThai;
                viewModel.LastNameThai = employee.LastNameThai;
                viewModel.Height = employee.Height;
                viewModel.Hand = employee.Hand;
                viewModel.Gender = employee.Gender;
                viewModel.BirthDate = employee.BirthDate;
                viewModel.HireType = employee.HireType;
                viewModel.HireDate = employee.HireDate;

                if (employee.EmployeeState != null)
                {
                    viewModel.DepartmentId = employee.EmployeeState.JobFunction.Section.Department.DepartmentId;
                    viewModel.SectionId = employee.EmployeeState.JobFunction.Section.SectionId;
                    viewModel.ShiftId = employee.EmployeeState.ShiftId;
                    viewModel.JobPositionId = employee.EmployeeState.PositionId;
                    viewModel.JobFunctionId = employee.EmployeeState.JobFunctionId;
                    viewModel.LevelId = employee.EmployeeState.LevelId;
                    viewModel.RouteId = employee.EmployeeState.BusStation.Route.RouteId;
                    viewModel.BusStationId = employee.EmployeeState.BusStationId;
                    viewModel.JoinDate = employee.EmployeeState.JoinDate;
                }
            }

            //var employeeState = await _employeeStateService.GetByEmployeeId(employeeId);

            //if (employeeState != null)
            //{
            //    viewModel.DepartmentId = employeeState.JobFunction.Section.Department.DepartmentId;
            //    viewModel.SectionId = employeeState.JobFunction.Section.SectionId;
            //    viewModel.ShiftId = employeeState.ShiftId;
            //    viewModel.JobPositionId = employeeState.PositionId;
            //    viewModel.JobFunctionId = employeeState.JobFunctionId;
            //    viewModel.LevelId = employeeState.LevelId;
            //    viewModel.BusStationId = employeeState.BusStationId;
            //    viewModel.JoinDate = employeeState.JoinDate;
            //}

            var address = await _employeeAddressService.GetByEmployeeId(employeeId);

            if (address != null)
            {
                viewModel.EmployeeAddressId = address.EmployeeAddressId;
                viewModel.HomeAddress = address.HomeAddress;
                viewModel.City = address.City;
                viewModel.Country = address.Country;
                viewModel.PostalCode = address.PostalCode;
                viewModel.PhoneNumber = address.PhoneNumber;
                viewModel.EmailAddress = address.EmailAddress;
            }

            return viewModel;
        }

        public async Task UpdateProfile(ProfileEditViewModel model)
        {
            if (model.EmployeeImage != null)
            {
                var employeeImage = new EmployeeImageModel
                {
                    ImageId = model.ImageId,
                    EmployeeId = model.EmployeeId,
                };

                using (var memoryStream = new MemoryStream())
                {
                    await model.EmployeeImage.CopyToAsync(memoryStream);
                    employeeImage.Images = memoryStream.ToArray();
                }

                var existingImage = await _employeeImageService.ExistsAsync(model.EmployeeId);

                if (existingImage)
                    await _employeeImageService.UpdateAsync(employeeImage);
                else
                    await _employeeImageService.AddAsync(employeeImage);
            }

            // update employee
            var employee = new EmployeeModel
            {
                EmployeeId = model.EmployeeId,
                GlobalId = model.GlobalId,
                CardId = model.CardId,
                Title = model.Title,
                TitleThai = model.TitleThai,
                EmployeeType = model.EmployeeType,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FirstNameThai = model.FirstNameThai,
                LastNameThai = model.LastNameThai,
                Gender = model.Gender,
                Hand = model.Hand,
                Height = model.Height,
                BirthDate = model.BirthDate,
                HireType = model.HireType,
                HireDate = model.HireDate,
                AvailableFlag = true,
                ChangedDate = DateTime.Now,
            };

            await _employeeService.UpdateAsync(employee);

            // add or update employee state
            var employeeState = new EmployeeStateModel
            {
                EmployeeId = model.EmployeeId,
                ShiftId = (byte)model.ShiftId,
                LevelId = model.LevelId,
                PositionId = model.JobPositionId,
                JobFunctionId = model.JobFunctionId,
                BusStationId = model.BusStationId,
                JoinDate = model.JoinDate,
                ChangedDate = DateTime.Now
            };

            var existEmployeeState = await _employeeStateService.ExistsAsync(model.EmployeeId);

            if (existEmployeeState)
                await _employeeStateService.UpdateAsync(employeeState);
            else
                await _employeeStateService.AddAsync(employeeState);

            // add or update address
            var address = new EmployeeAddressModel
            {
                EmployeeAddressId = model.EmployeeAddressId,
                EmployeeId = model.EmployeeId,
                HomeAddress = model.HomeAddress,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                ChangedDate = DateTime.Now
            };

            if (address.EmployeeAddressId > 0)
                await _employeeAddressService.UpdateAsync(address);
            else
                await _employeeAddressService.AddAsync(address);

        }

        public async Task<IEnumerable<SelectListItem>> GetSectionsByDepartmentId(int departmentId)
        {
            return await _employeeDetailService.GetSectionsByDepartmentId(departmentId);
        }

        public async Task<IEnumerable<SelectListItem>> GetJobFunctionBySectionId(int sectionId)
        {
            return await _employeeDetailService.GetJobFunctionsBySectionId(sectionId);
        }

        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        public int CalculateDurationOfEmployment(DateTime hierDate)
        {
            var today = DateTime.Today;
            var duration = today.Year - hierDate.Year;
            if (hierDate > today.AddYears(-duration)) duration--;
            return duration;
        }


    }
}