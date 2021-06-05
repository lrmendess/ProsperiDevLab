using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ProsperiDevLab.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IDbContextTransaction BeginTransaction();
    }
}
