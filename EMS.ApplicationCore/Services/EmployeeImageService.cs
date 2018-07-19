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
    public class EmployeeImageService : IEmployeeImageService
    {
        private readonly IAsyncRepository<EmployeeImage> _repository;

        public EmployeeImageService(IAsyncRepository<EmployeeImage> repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeImageModel> AddAsync(EmployeeImageModel model)
        {
            var entity = new EmployeeImage
            {

                ImageId = model.ImageId,
                EmployeeId = model.EmployeeId,
                Images = model.Images
            };

            entity = await _repository.AddAsync(entity);
            return MappingEntityAndModel(entity);
        }

        public async Task UpdateAsync(EmployeeImageModel model)
        {
            var entity = await _repository.GetByIdAsync(model.ImageId);

            entity.EmployeeId = model.EmployeeId;
            entity.Images = model.Images;

            await _repository.UpdateAsync(entity);
        }

        private EmployeeImageModel MappingEntityAndModel(EmployeeImage entity)
        {
            return new EmployeeImageModel
            {
                ImageId = entity.ImageId,
                EmployeeId = entity.EmployeeId,
                Images = entity.Images
            };
        }
    }
}
