using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
