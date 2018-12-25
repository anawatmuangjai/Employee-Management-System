﻿using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;

namespace EMS.WebCore.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public string EmployeeId { get; set; }

        public string GlobalId { get; set; }

        public string CardId { get; set; }

        public string Title { get; set; }

        public string TitleThai { get; set; }

        public string EmployeeType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstNameThai { get; set; }

        public string LastNameThai { get; set; }

        public decimal Height { get; set; }

        public string Hand { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string HireType { get; set; }

        public DateTime HireDate { get; set; }

        public int EmploymentDuration { get; set; }

        public string DepartmentName { get; set; }

        public string SectionName { get; set; }

        public string ShiftName { get; set; }

        public string LevelCode { get; set; }

        public string PositionName { get; set; }

        public string FunctionName { get; set; }

        public string FunctionCode { get; set; }

        public string RouteName { get; set; }

        public string BusStationName { get; set; }

        public bool Status { get; set; }

        public DateTime JoinDate { get; set; }

        public string HomeAddress { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string ProfileImage { get; set; }

        public IEnumerable<EmployeeSkillModel> EmployeeSkills { get; set; }
    }
}