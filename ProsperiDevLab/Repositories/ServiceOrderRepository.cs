using Microsoft.EntityFrameworkCore;
using ProsperiDevLab.Data;
using ProsperiDevLab.Models;
using ProsperiDevLab.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProsperiDevLab.Repositories
{
    public class ServiceOrderRepository : CrudRepository<long, ServiceOrder>, IServiceOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceOrderRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public override ServiceOrder Get(long id)
        {
            return _context.ServiceOrders
                .Include(s => s.Price)
                    .ThenInclude(p => p.Currency)
                .Include(s => s.Employee)
                .Include(s => s.Customer)
                .FirstOrDefault(s => s.Id == id);
        }

        public override ICollection<ServiceOrder> GetAll()
        {
            return _context.ServiceOrders
                .Include(s => s.Price)
                    .ThenInclude(p => p.Currency)
                .Include(s => s.Employee)
                .Include(s => s.Customer)
                .ToList();
        }

        public ServiceOrder GetWithPrice(long id)
        {
            return _context.ServiceOrders
                .Include(s => s.Price)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}
