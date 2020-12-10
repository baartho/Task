using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;

namespace TaskableChallenge.Model.Orders.Infrastructure
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order Order);
        Order Update(Order Order);
        Task<Order> FindByIdAsync(int id);
    }
}
