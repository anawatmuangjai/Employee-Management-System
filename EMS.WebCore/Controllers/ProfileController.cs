using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMS.ApplicationCore.Models;

namespace EMS.WebCore.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProfileViewModelService _profileViewModelService;
        private readonly IEmployeeImageService _employeeImageService;

        public ProfileController(
            IHttpContextAccessor httpContextAccessor,
            IProfileViewModelService profileViewModelService,
            IEmployeeImageService employeeImageService)
        {
            _httpContextAccessor = httpContextAccessor;
            _profileViewModelService = profileViewModelService;
            _employeeImageService = employeeImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeeId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var viewModel = await _profileViewModelService.GetProfile(employeeId);
            return View(viewModel);
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
            //if (!ModelState.IsValid)
            //    return View();

            await _profileViewModelService.UpdateProfile(model);
            return RedirectToAction(nameof(Index));
        }
    }
}