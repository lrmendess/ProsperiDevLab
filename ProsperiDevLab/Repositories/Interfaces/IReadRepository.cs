using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface IReadRepository<TKey, TEntity> : IDisposable
        where TKey : struct
        where TEntity : class
    {
        TEntity Get(TKey id);
        ICollection<TEntity> GetAll();
        ICollection<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    }
}
