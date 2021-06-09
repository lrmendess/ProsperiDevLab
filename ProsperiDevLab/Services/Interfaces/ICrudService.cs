using System;
using System.Collections.Generic;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface ICrudService<TKey, TEntity, TRepository> : IReadService<TKey, TEntity, TRepository>, IDisposable
        where TKey : struct
        where TEntity : class
        where TRepository : ICrudRepository<TKey, TEntity>
    {
        void Create(TEntity entity, params string[] ruleSets);
        void Update(TEntity entity, params string[] ruleSets);
        void Remove(TKey id);
    }
}
