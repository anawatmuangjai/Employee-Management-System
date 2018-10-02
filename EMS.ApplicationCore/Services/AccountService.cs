using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterAccount> _accountRepository;

        public AccountService(IAsyncRepository<MasterAccount> accountRepository)
        {
            _accountRepository = accountRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterAccount, AccountModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<AccountModel> GetByIdAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            return _mapper.Map<MasterAccount, AccountModel>(account);
        }

        public async Task<AccountModel> GetByUserNameAsync(string username)
        {
            var account = await _accountRepository.GetSingleAsync(x => x.UserName == username);
            return _mapper.Map<MasterAccount, AccountModel>(account);
        }

        public async Task<List<AccountModel>> GetAllAsync()
        {
            var account = await _accountRepository.GetAllAsync();
            return _mapper.Map<List<MasterAccount>, List<AccountModel>>(account);
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await _accountRepository.ExistsAsync(x => x.UserName == username);
        }

        public async Task<AccountModel> AddAsync(AccountModel model)
        {
            var account = new MasterAccount
            {
                UserName = model.UserName,
                PasswordHash = model.PasswordHash,
                PasswordSalt = model.PasswordSalt,
                ChangeDate = model.ChangeDate
            };

            account = await _accountRepository.AddAsync(account);

            return _mapper.Map<MasterAccount, AccountModel>(account);
        }

        public async Task UpdateAsync(AccountModel model)
        {
            var entity = await _accountRepository.GetByIdAsync(model.AccountId);

            entity.UserName = model.UserName;
            entity.PasswordHash = model.PasswordHash;
            entity.PasswordSalt = model.PasswordSalt;
            entity.ChangeDate = model.ChangeDate;

            await _accountRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            await _accountRepository.DeleteAsync(account);
        }
    }
}
