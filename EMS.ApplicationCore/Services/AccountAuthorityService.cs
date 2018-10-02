using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Specifications;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class AccountAuthorityService : IAccountAuthorityService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterAccountAuthority> _accountAuthorityRepository;

        public AccountAuthorityService(IAsyncRepository<MasterAccountAuthority> accountAuthorityRepository)
        {
            _accountAuthorityRepository = accountAuthorityRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterAccountAuthority, AccountAuthorityModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<AccountAuthorityModel> GetByIdAsync(int id)
        {
            var spec = new AuthoritySpecification(x => x.AccountId == id);
            var authority = await _accountAuthorityRepository.GetSingleAsync(spec);
            return _mapper.Map<MasterAccountAuthority, AccountAuthorityModel>(authority);
        }

        public async Task<List<AccountAuthorityModel>> GetAllAsync()
        {
            var authorities = await _accountAuthorityRepository.GetAllAsync();
            return _mapper.Map<List<MasterAccountAuthority>, List<AccountAuthorityModel>>(authorities);
        }

        public async Task AddAsync(AccountAuthorityModel model)
        {
            var accountAuthority = new MasterAccountAuthority
            {
                AccountId = model.AccountId,
                AuthorityId = model.AuthorityId
            };

            await _accountAuthorityRepository.AddAsync(accountAuthority);
        }

    }
}
