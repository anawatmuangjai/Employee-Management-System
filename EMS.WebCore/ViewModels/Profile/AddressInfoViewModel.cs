using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Profile
{
    public class AddressInfoViewModel
    {
        public int EmployeeAddressId { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string HomeAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public ProfileHeaderViewModel ProfileHeader { get; set; }
    }
}
