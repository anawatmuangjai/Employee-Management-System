using EMS.ApplicationCore.Interfaces;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain;
using EMS.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Repositories
{
    public class Repository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly EmployeeContext _dbContext;

        public Repository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter).FirstOrDefault();
        }

        public async Task<T> GetSingleAsync(ISpecification<T> spec)
        {
            var queryWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            var queryResult = spec.IncludeStrings
                .Aggregate(queryWithIncludes,
                (current, include) => current.Include(include));

            return await queryResult.Where(spec.Filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter).ToList();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetAsync(ISpecification<T> spec)
        {
            var queryWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            var queryResult = spec.IncludeStrings
                .Aggregate(queryWithIncludes,
                (current, include) => current.Include(include));

            return await queryResult.Where(spec.Filter).ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


    }
}
