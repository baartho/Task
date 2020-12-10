using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;
using TaskableChallenge.Model.Orders;
using TaskableChallenge.Model.Orders.Infrastructure;
using TaskableChallenge.Server.Data;

namespace TaskableChallenge.Server.Infrastructure
{
    public class OrderRepository
        : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Order Add(Order Order)
        {
            return _context.Orders
                    .Add(Order)
                    .Entity;
        }

        public Order Update(Order Order)
        {
            return _context.Orders
                    .Update(Order)
                    .Entity;
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            var Order = await _context.Orders
                .Include(b => b.Lines)
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return Order;
        }
    }
}
