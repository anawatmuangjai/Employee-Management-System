using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.ViewModels.SkillMapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SkillMappingController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeSkillService _employeeSkillService;
        private readonly IEmployeeImageService _employeeImageService;

        public SkillMappingController(
            IEmployeeService employeeService,
            IEmployeeSkillService employeeSkillService,
            IEmployeeImageService employeeImageService)
        {
            _employeeService = employeeService;
            _employeeSkillService = employeeSkillService;
            _employeeImageService = employeeImageService;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(string firstEmployeeId, string secondEmployeeId)
        {
            var viewModel = new SkillMappingViewModel();

            if (!string.IsNullOrEmpty(firstEmployeeId))
            {
                var image = await _employeeImageService.GetByEmployeeId(firstEmployeeId);

                if (image != null)
                {
                    var imageBase64Data = Convert.ToBase64String(image.Images);
                    viewModel.FirstProfileImage = string.Format("data:image/png;base64,{0}", imageBase64Data);
                }

                viewModel.FirstEmployee = await _employeeService.GetByEmployeeIdWithDetailAsync(firstEmployeeId);
                viewModel.FirstEmployeeSkills = await _employeeSkillService.GetByEmployeeId(firstEmployeeId);
            }

            if (!string.IsNullOrEmpty(secondEmployeeId))
            {
                var image = await _employeeImageService.GetByEmployeeId(secondEmployeeId);

                if (image != null)
                {
                    var imageBase64Data = Convert.ToBase64String(image.Images);
                    viewModel.SecondProfileImage = string.Format("data:image/png;base64,{0}", imageBase64Data);
                }

                viewModel.SecondEmployee = await _employeeService.GetByEmployeeIdWithDetailAsync(firstEmployeeId);
                viewModel.SecondEmployeeSkills = await _employeeSkillService.GetByEmployeeId(firstEmployeeId);
            }

            return View(viewModel);
        }
    }
}