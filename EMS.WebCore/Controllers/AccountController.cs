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
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

            // Go to change password page if password = null
            var user = await _accountService.GetPasswordAsync(loginViewModel.UserName);

            if (user == null)
            {
                ModelState.AddModelError("Error", "User name or password is not valid.");
                return View(loginViewModel);
            }

            // Check password
            var isCorrect = _accountService.VerifyPassword(loginViewModel.Password, user.PasswordHash, user.PasswordSalt);
            if (isCorrect == false)
            {
                ModelState.AddModelError("Error", "Password is not valid.");
                return View(loginViewModel);
            }

            // Add cookie authentication
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.EmployeeId),
                new Claim("FullName", user.EmployeeId),
                new Claim(ClaimTypes.Role, "Administrator"),
                //new Claim(ClaimTypes.Role, "user.Role"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                registerViewModel.EmployeeId = registerViewModel.EmployeeId.ToLower();

                if (await _accountService.Exists(registerViewModel.EmployeeId))
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View();
                }

                await _accountService.RegisterEmployee(registerViewModel);

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

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
