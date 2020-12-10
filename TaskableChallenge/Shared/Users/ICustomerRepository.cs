using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;

namespace TaskableChallenge.Model.Users
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(Customer Order);
        Customer Update(Customer Order);
        Task<Customer> FindByIdAsync(string id);
    }
}
