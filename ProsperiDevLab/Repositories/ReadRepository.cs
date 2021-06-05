using ProsperiDevLab.Data;
using ProsperiDevLab.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProsperiDevLab.Repositories
{
    public abstract class ReadRepository<TKey, TEntity> : IReadRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual ICollection<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual void Dispose()
        {
            _context?.Dispose();
        }
    }
}
