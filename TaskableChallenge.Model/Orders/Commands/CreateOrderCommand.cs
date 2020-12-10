using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Orders.Infrastructure;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShoppingCarts;
using TaskableChallenge.Model.Users;

namespace TaskableChallenge.Model.Orders.Commands
{
    public class CreateOrderCommand
    {
        readonly ICustomerRepository customerRepository;
        readonly IOrderRepository orderRepository;

        public CreateOrderCommand(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<Order> Execute(int customerId, List<ShoppingCartItem> items)
        {
            Order order1 = new Order(customerId, items);
            order1.Purchase();
            orderRepository.Add(order1);
            await orderRepository.UnitOfWork.SaveEntitiesAsync();

            return order1;
        }
    }
}
