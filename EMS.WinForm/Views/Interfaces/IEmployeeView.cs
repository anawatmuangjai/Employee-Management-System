using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Views.Interfaces
{
    public interface IEmployeeView
    {
        int EmployeeId { get; set; }
        string GlobalId { get; set; }
        string CardId { get; set; }
        string EmployeeType { get; set; }
        string Title { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FirstNameThai { get; set; }
        string LastNameThai { get; set; }
        string Gender { get; set; }
        bool AvailableFlag { get; set; }

        string Address { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string PhoneNumber { get; set; }
        string EmailAddress { get; set; }

        int DepartmentId { get; set; }
        int SectionId { get; set; }
        byte ShiftId { get; set; }
        int JobId { get; set; }
        int LevelId { get; set; }

        byte[] EmployeeImage { get; set; }

        DateTime BirthDate { get; }
        DateTime HireDate { get; }
        DateTime JoinDate { get; }
        DateTime ChangedDate { get; }

        IList<JobModel> Jobs { set; }
        IList<EmployeeLevelModel> Levels { set; }
        IList<DepartmentModel> Departments { set; }
        IList<SectionModel> Sections { set; }
        IList<ShiftModel> Shifts { set; }

        EmployeePresenter Presenter { set; }
    }
}
