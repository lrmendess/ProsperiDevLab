using FluentValidation;
using Microsoft.Extensions.Logging;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;
using System;
using System.Linq;

namespace ProsperiDevLab.Services
{
    public class CrudService<TKey, TEntity, TRepository> : ReadService<TKey, TEntity, TRepository>, ICrudService<TKey, TEntity, TRepository>
        where TKey : struct
        where TEntity : class, new()
        where TRepository : ICrudRepository<TKey, TEntity>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly TRepository CrudRepository;
        protected readonly AbstractValidator<TEntity> DefaultValidator;
        protected readonly ILogger Logger;

        public CrudService(IUnitOfWork unitOfWork, TRepository repository, AbstractValidator<TEntity> validator, INotificator notificator, ILogger logger)
            : base(repository, notificator)
        {
            UnitOfWork = unitOfWork;
            CrudRepository = repository;
            DefaultValidator = validator;
            Logger = logger;
        }

        public virtual void Create(TEntity entity, params string[] ruleSets)
        {
            var rules = ruleSets.Any() ? ruleSets : new[] { "default", "create" };

            if (!IsValid(DefaultValidator, entity, rules))
            {
                return;
            }

            try
            {
                CrudRepository.Create(entity);
                UnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                Notify(NotificationType.ERROR, string.Empty, $"There was an error adding {typeof(TEntity).Name}.");
            }
        }

        public virtual void Update(TEntity entity, params string[] ruleSets)
        {
            var rules = ruleSets.Any() ? ruleSets : new[] { "default", "update" };

            if (!IsValid(DefaultValidator, entity, rules))
            {
                return;
            }

            try
            {
                CrudRepository.Update(entity);
                UnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                Notify(NotificationType.ERROR, string.Empty, $"There was an error updating {typeof(TEntity).Name}.");
            }
        }

        public virtual void Remove(TKey id)
        {
            try
            {
                var entity = CrudRepository.Get(id);

                if (entity == null)
                {
                    Notify(NotificationType.ERROR, string.Empty, $"{typeof(TEntity).Name} not found.");
                    return;
                }

                CrudRepository.Remove(entity);
                UnitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                Notify(NotificationType.ERROR, string.Empty, $"There was an error removing {typeof(TEntity).Name}.");
            }
        }

        public override void Dispose()
        {
            UnitOfWork?.Dispose();
            CrudRepository?.Dispose();
        }
    }
}
