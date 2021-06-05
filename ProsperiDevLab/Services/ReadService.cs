using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Utils;
using System.Collections.Generic;

namespace ProsperiDevLab.Services
{
    public class ReadService<TKey, TEntity, TRepository> : IReadService<TKey, TEntity, TRepository>
        where TKey : struct
        where TEntity : class
        where TRepository : IReadRepository<TKey, TEntity>
    {
        private readonly TRepository _repository;

        public ReadService(TRepository repository)
        {
            _repository = repository;
        }

        public virtual TEntity Get(TKey id)
        {
            return _repository.Get(id);
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
