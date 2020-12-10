using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;
using TaskableChallenge.Model.Users;
using TaskableChallenge.Server.Data;

namespace TaskableChallenge.Server.Infrastructure
{
    public class CustomerRepository
        : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Customer Add(Customer Customer)
        {
            return _context.Customers
                    .Add(Customer)
                    .Entity;
        }

        public Customer Update(Customer Customer)
        {
            return _context.Customers
                    .Update(Customer)
                    .Entity;
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            var Customer = await _context.Customers
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return Customer;
        }
    }
}
