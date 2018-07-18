using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IService<M, E, R>
    {
        Task<M> GetByIdAsync(int id);
        Task<M> GetSingleAsync(Expression<Func<E, bool>> filter);
        Task<List<M>> GetAllAsync();
        Task<List<M>> GetAsync(Expression<Func<E, bool>> filter);
        Task<M> AddAsync(M model);
        Task UpdateAsync(M model);
        Task DeleteAsync(M model);
    }
}
