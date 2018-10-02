using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAccountService _accountService;
        private readonly IAuthorityService _authorityService;
        private readonly IAccountAuthorityService _accountAuthorityService;

        public AuthenService(
            IEmployeeService employeeService,
            IAccountService accountService,
            IAuthorityService authorityService,
            IAccountAuthorityService accountAuthorityService)
        {
            _employeeService = employeeService;
            _accountService = accountService;
            _authorityService = authorityService;
            _accountAuthorityService = accountAuthorityService;
        }

        public async Task<string> GetRoleAsync(int accountId)
        {
            var roleName = string.Empty;

            var accountAuthority = await _accountAuthorityService.GetByIdAsync(accountId);

            if (accountAuthority != null)
            {
                roleName = accountAuthority.Authority.AuthorityName;
            }

            return roleName;
        }

        public async Task<AccountModel> CreateAccountAsync(string username, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CreatePassword(password, out passwordHash, out passwordSalt);

            var account = new AccountModel
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                ChangeDate = DateTime.Now
            };

            return await _accountService.AddAsync(account);
        }

        public async Task CreateRoleAsync(string role)
        {
            var authority = new AuthorityModel
            {
                AuthorityName = role
            };

            await _authorityService.AddAsync(authority);
        }

        public async Task AddUserRoleAsync(AccountModel account, string role)
        {
            var authority = await _authorityService.GetByNameAsync(role);

            var accountAuthority = new AccountAuthorityModel
            {
                AccountId = account.AccountId,
                AuthorityId = authority.AuthorityId,
            };

            await _accountAuthorityService.AddAsync(accountAuthority);
        }

        public async Task<AccountModel> SignInAsync(string username)
        {
            return await _accountService.GetByUserNameAsync(username);
        }

        public async Task<bool> AccountExistsAsync(string username)
        {
            return await _accountService.ExistsAsync(username);
        }

        public async Task<bool> RoleExistsAsync(string role)
        {
            return await _authorityService.ExistsAsync(role);
        }

        public void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }


    }
}
