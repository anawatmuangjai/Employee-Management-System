using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Services
{
    public abstract class BaseService<M, E, R> : IService<M, E, R>
        where R : IRepository<E>
        where E : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly R _repository;

        protected BaseService(R repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<E, M>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public IEnumerable<M> Get(Expression<Func<E, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<M> GetAll()
        {
            var entities = _repository.GetAll();

            var model = _mapper.Map<IEnumerable<E>, IEnumerable<M>>(entities);

            return model;
        }

        public M GetSingle(Expression<Func<E, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(M model)
        {
            var entity = _mapper.Map<M, E>(model);
            _repository.Add(entity);
        }

        public void Update(M model)
        {
            var entity = _mapper.Map<M, E>(model);
            _repository.Update(entity);
        }

        public void Delete(M model)
        {
            var entity = _mapper.Map<M, E>(model);
            _repository.Delete(entity);
        }
    }
}
