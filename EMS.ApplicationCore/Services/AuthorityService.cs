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
    public class AuthorityService : IAuthorityService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterAuthority> _authorityRepository;

        public AuthorityService(IAsyncRepository<MasterAuthority> authorityRepository)
        {
            _authorityRepository = authorityRepository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterAuthority, AuthorityModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<AuthorityModel> GetByIdAsync(int id)
        {
            var authority = await _authorityRepository.GetByIdAsync(id);
            return _mapper.Map<MasterAuthority, AuthorityModel>(authority);
        }

        public async Task<AuthorityModel> GetByNameAsync(string name)
        {
            var authority = await _authorityRepository.GetSingleAsync(x => x.AuthorityName == name);
            return _mapper.Map<MasterAuthority, AuthorityModel>(authority);
        }

        public async Task<List<AuthorityModel>> GetAllAsync()
        {
            var routes = await _authorityRepository.GetAllAsync();
            return _mapper.Map<List<MasterAuthority>, List<AuthorityModel>>(routes);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _authorityRepository.ExistsAsync(x => x.AuthorityName == name);
        }

        public async Task AddAsync(AuthorityModel model)
        {
            var authority = new MasterAuthority
            {
                AuthorityName = model.AuthorityName
            };

            await _authorityRepository.AddAsync(authority);
        }

        public async Task UpdateAsync(AuthorityModel model)
        {
            var entity = await _authorityRepository.GetByIdAsync(model.AuthorityId);

            entity.AuthorityName = model.AuthorityName;

            await _authorityRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var authority = await _authorityRepository.GetByIdAsync(id);
            await _authorityRepository.DeleteAsync(authority);
        }


    }
}
