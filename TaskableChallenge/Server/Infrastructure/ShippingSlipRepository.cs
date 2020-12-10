using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;
using TaskableChallenge.Model.ShippingSlips;
using TaskableChallenge.Model.ShippingSlips.Infrastructure;
using TaskableChallenge.Server.Data;

namespace TaskableChallenge.Server.Infrastructure
{
    public class ShippingSlipRepository
        : IShippingSlipRepository
    {
        private readonly ApplicationDbContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ShippingSlipRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ShippingSlip Add(ShippingSlip ShippingSlip)
        {
            return _context.ShippingSlips
                    .Add(ShippingSlip)
                    .Entity;
        }

        public ShippingSlip Update(ShippingSlip ShippingSlip)
        {
            return _context.ShippingSlips
                    .Update(ShippingSlip)
                    .Entity;
        }

        public async Task<ShippingSlip> FindByIdAsync(int id)
        {
            var ShippingSlip = await _context.ShippingSlips
                .Include(b => b.Lines)
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return ShippingSlip;
        }

        public async Task<ShippingSlip> FindByOrderIdAsync(int orderId)
        {
            return await _context.ShippingSlips
                .Where(x => x.OrderId == orderId)
                .SingleOrDefaultAsync();
        }
    }
}
