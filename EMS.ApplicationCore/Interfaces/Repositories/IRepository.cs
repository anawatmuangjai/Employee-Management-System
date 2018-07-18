using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
