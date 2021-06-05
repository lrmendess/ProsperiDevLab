using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services.Interfaces;

namespace ProsperiDevLab.Services
{
    public class CrudService<TKey, TEntity, TRepository> : ReadService<TKey, TEntity, TRepository>, ICrudService<TKey, TEntity, TRepository>
        where TKey : struct
        where TEntity : class, new()
        where TRepository : ICrudRepository<TKey, TEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TRepository _repository;

        public CrudService(IUnitOfWork unitOfWork, TRepository repository)
            : base(repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            _repository.Create(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void Remove(TKey id)
        {
            _repository.Remove(_repository.Get(id));
            _unitOfWork.SaveChanges();
        }

        public override void Dispose()
        {
            _unitOfWork?.Dispose();
            _repository?.Dispose();
        }
    }
}
