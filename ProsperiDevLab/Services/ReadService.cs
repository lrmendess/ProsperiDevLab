using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;
using ProsperiDevLab.Services.Utils;
using System.Collections.Generic;

namespace ProsperiDevLab.Services
{
    public class ReadService<TKey, TEntity, TRepository> : BaseService, IReadService<TKey, TEntity, TRepository>
        where TKey : struct
        where TEntity : class
        where TRepository : IReadRepository<TKey, TEntity>
    {
        protected readonly TRepository ReadRepository;

        public ReadService(TRepository repository, INotificator notificator)
            : base(notificator)
        {
            ReadRepository = repository;
        }

        public virtual TEntity Get(TKey id)
        {
            var entity = ReadRepository.Get(id);

            if (entity == null)
            {
                Notify(NotificationType.ERROR, typeof(TEntity).Name, $"{typeof(TEntity).Name} not found.");
            }

            return entity;
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return ReadRepository.GetAll();
        }

        public virtual void Dispose()
        {
            ReadRepository?.Dispose();
        }
    }
}
