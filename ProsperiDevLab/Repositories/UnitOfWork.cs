using Microsoft.EntityFrameworkCore.Storage;
using ProsperiDevLab.Data;
using ProsperiDevLab.Repositories.Interfaces;

namespace ProsperiDevLab.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
