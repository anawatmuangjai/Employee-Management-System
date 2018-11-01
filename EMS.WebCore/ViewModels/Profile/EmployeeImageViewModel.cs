using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.ViewModels.Profile
{
    public class EmployeeImageViewModel
    {
        public int ImageId { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        public IFormFile EmployeeImage { get; set; }

        public ProfileHeaderViewModel ProfileHeader { get; set; }
    }
}
