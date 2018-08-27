using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Profile;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileViewModelService _profileViewModelService;

        public ProfileController(IProfileViewModelService profileViewModelService)
        {
            _profileViewModelService = profileViewModelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string employeeId)
        {
            var viewModel = await _profileViewModelService.EditProfile(employeeId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            await _profileViewModelService.UpdateProfile(model);
            return RedirectToAction(nameof(Index));
        }
    }
}