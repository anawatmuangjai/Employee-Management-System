using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Profile;
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
                viewModel.FirstName = employee.FirstName;
                viewModel.LastName = employee.LastName;
                viewModel.FirstNameThai = employee.FirstNameThai;
                viewModel.LastNameThai = employee.LastNameThai;
                viewModel.Gender = employee.Gender;
                viewModel.Age = CalculateAge(employee.BirthDate);
                viewModel.BirthDate = employee.BirthDate;
                viewModel.HireDate = employee.HireDate;
                viewModel.EmploymentDuration = CalculateDurationOfEmployment(employee.HireDate);

                if (employee.EmployeeState != null)
                {
                    viewModel.DepartmentName = employee.EmployeeState.Department.DepartmentName;
                    viewModel.SectionName = employee.EmployeeState.Section.SectionName;
                    viewModel.ShiftName = employee.EmployeeState.Shift.ShiftName;
                    viewModel.LevelCode = employee.EmployeeState.Level.LevelName;
                    viewModel.PositionName = employee.EmployeeState.Position.PositionName;
                    viewModel.FunctionName = employee.EmployeeState.JobFunction.FunctionName;
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
            viewModel.Sections = await _employeeDetailService.GetSections();
            viewModel.Shifts = await _employeeDetailService.GetShifts();
            viewModel.JobTitles = await _employeeDetailService.GetPositions();
            viewModel.JobFunctions = await _employeeDetailService.GetJobFunctions();
            viewModel.JobLevels = await _employeeDetailService.GetLevels();
            viewModel.BusStations = await _employeeDetailService.GetBusStations();

            var employee = await _employeeService.GetByEmployeeIdAsync(employeeId);

            if (employee != null)
            {
                viewModel.EmployeeId = employee.EmployeeId;
                viewModel.GlobalId = employee.GlobalId;
                viewModel.CardId = employee.CardId;
                viewModel.Title = employee.Title;
                viewModel.EmployeeType = employee.EmployeeType;
                viewModel.FirstName = employee.FirstName;
                viewModel.LastName = employee.LastName;
                viewModel.FirstNameThai = employee.FirstNameThai;
                viewModel.LastNameThai = employee.LastNameThai;
                viewModel.Gender = employee.Gender;
                viewModel.BirthDate = employee.BirthDate;
                viewModel.HireDate = employee.HireDate;
            }

            var employeeState = await _employeeStateService.GetByEmployeeId(employeeId);

            if (employeeState != null)
            {
                viewModel.DepartmentId = employeeState.DepartmentId;
                viewModel.SectionId = employeeState.SectionId;
                viewModel.ShiftId = employeeState.ShiftId;
                viewModel.JobPositionId = employeeState.PositionId;
                viewModel.JobFunctionId = employeeState.JobFunctionId;
                viewModel.LevelId = employeeState.LevelId;
                viewModel.BusStationId = employeeState.BusStationId;
                viewModel.JoinDate = employeeState.JoinDate;
            }

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

            // add or update employee
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
                BirthDate = model.BirthDate,
                HireDate = model.HireDate,
                AvailableFlag = true,
                ChangedDate = DateTime.Now,
            };

            await _employeeService.UpdateAsync(employee);

            // add or update employee state
            var employeeState = new EmployeeStateModel
            {
                EmployeeId = model.EmployeeId,
                DepartmentId = model.DepartmentId,
                SectionId = model.SectionId,
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

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        private int CalculateDurationOfEmployment(DateTime hierDate)
        {
            var today = DateTime.Today;
            var duration = today.Year - hierDate.Year;
            if (hierDate > today.AddYears(-duration)) duration--;
            return duration;
        }
    }
}