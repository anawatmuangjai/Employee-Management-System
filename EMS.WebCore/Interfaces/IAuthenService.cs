using EMS.ApplicationCore.Models;
using System.Threading.Tasks;

namespace EMS.WebCore.Interfaces
{
    public interface IAuthenService
    {
        Task<string> GetRoleAsync(int accountId);

        Task<AccountModel> CreateAccountAsync(string username, string password);

        Task CreateRoleAsync(string role);

        Task AddUserRoleAsync(AccountModel account, string role);

        Task<AccountModel> SignInAsync(string username);

        Task<bool> AccountExistsAsync(string username);

        Task<bool> RoleExistsAsync(string role);

        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}