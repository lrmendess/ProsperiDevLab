using Microsoft.EntityFrameworkCore;
using ProsperiDevLab.Data;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Repositories
{
    public abstract class CrudRepository<TKey, TEntity> : ReadRepository<TKey, TEntity>, ICrudRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        private readonly DbContext _context;

        public CrudRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public override void Dispose()
        {
            _context?.Dispose();
        }
    }
}
