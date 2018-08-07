using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeePasswordService _passwordService;
        private readonly IEmployeeRegisterService _registerService;

        public AccountController(IEmployeePasswordService passwordService,
            IEmployeeRegisterService registerService)
        {
            _passwordService = passwordService;
            _registerService = registerService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _passwordService.GetByEmployeeId(loginViewModel.UserName);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.EmployeeId)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Employee");
            }

            ModelState.AddModelError("", "User name or password not found");
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var viewModel = await _registerService.GetRegisterViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                registerViewModel.EmployeeId = registerViewModel.EmployeeId.ToLower();

                if (await _registerService.Exists(registerViewModel.EmployeeId))
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View();
                }

                await _registerService.RegisterEmployee(registerViewModel);

                return RedirectToAction(nameof(Login));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
