using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeePasswordService _passwordService;

        public AccountController(IEmployeePasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _passwordService.GetByEmployeeId(loginViewModel.UserName);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "User name or password not found");
            return View(loginViewModel);
        }
    }
}
