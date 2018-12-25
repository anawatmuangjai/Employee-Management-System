using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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