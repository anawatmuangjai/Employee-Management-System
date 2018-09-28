using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Employee ID must be 8 characters")]
        public string EmployeeId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Global ID must be 10 characters")]
        public string GlobalId { get; set; }

        [Required]
        public string CardId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 12 characters")]
        public string Password { get; set; }

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
        [StringLength(1, ErrorMessage = "String leangth must be 1 charactor")]
        public string Gender { get; set; }

        [Required]
        public decimal Height { get; set; }

        [Required]
        public string Hand { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
