using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Interfaces.Services
{
    public interface IService<M, E, R>
    {
        M GetSingle(Expression<Func<E, bool>> filter);
        IEnumerable<M> Get(Expression<Func<E, bool>> filter);
        IEnumerable<M> GetAll();
        void Add(M model);
        void Update(M model);
        void Delete(M model);
    }
}
