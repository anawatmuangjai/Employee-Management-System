using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Employee
{
    public class RegisterEmployeeViewModel
    {
        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string GlobalId { get; set; }

        [Required]
        public string CardId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string EmployeeType { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstNameThai { get; set; }

        [Required]
        public string LastNameThai { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
