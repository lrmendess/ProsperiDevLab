using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface ICrudRepository<TKey, TEntity> : IReadRepository<TKey, TEntity>, IDisposable
        where TKey : struct
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
