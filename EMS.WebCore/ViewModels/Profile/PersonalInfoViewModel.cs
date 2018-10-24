using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Profile
{
    public class PersonalInfoViewModel
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
        public string TitleThai { get; set; }

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
        public decimal Height { get; set; }

        [Required]
        public string Hand { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string HireType { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public bool AvailableFlag { get; set; }
    }
}
