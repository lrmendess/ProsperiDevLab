using ProsperiDevLab.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ProsperiDevLab.Services.Interfaces
{
    public interface IReadService<TKey, TEntity, TRepository> : IDisposable
        where TKey : struct
        where TEntity : class
        where TRepository : IReadRepository<TKey, TEntity>
    {
        TEntity Get(TKey id);
        ICollection<TEntity> GetAll();
    }
}
