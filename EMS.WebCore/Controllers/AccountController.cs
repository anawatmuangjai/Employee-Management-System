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
        private readonly IAuthenService _authenService;

        public AccountController(IAuthenService authenService)
        {
            _authenService = authenService;
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
            //var user = await _accountService.SignInAsync(loginViewModel.UserName);
            var account = await _authenService.SignInAsync(loginViewModel.UserName);

            if (account == null)
            {
                ModelState.AddModelError("Error", "User name or password is not valid.");
                return View(loginViewModel);
            }

            // Check password
            var isCorrect = _authenService.VerifyPassword(loginViewModel.Password, account.PasswordHash, account.PasswordSalt);
            if (isCorrect == false)
            {
                ModelState.AddModelError("Error", "Password is not valid.");
                return View(loginViewModel);
            }

            // Get user role
            var roleName = await _authenService.GetRoleAsync(account.AccountId);

            if (roleName == null)
            {
                ModelState.AddModelError("Error", "Authentication failed.");
                return View(loginViewModel);
            }

            // Add cookie authentication
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim("FullName", account.UserName),
                new Claim(ClaimTypes.Role, roleName),
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
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.UserName = viewModel.UserName.ToLower();

                if (await _authenService.AccountExistsAsync(viewModel.UserName))
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View(viewModel);
                }

                var account = await _authenService.CreateAccountAsync(viewModel.UserName, viewModel.Password);

                await _authenService.AddUserRoleAsync(account, "Member");

                return RedirectToAction(nameof(Login));
            }

            return View(viewModel);
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
