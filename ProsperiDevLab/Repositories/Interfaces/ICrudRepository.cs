using System;

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
