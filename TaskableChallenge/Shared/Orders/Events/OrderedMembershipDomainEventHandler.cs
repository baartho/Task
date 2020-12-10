using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskableChallenge.Model.Orders.Infrastructure;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.Users;

namespace TaskableChallenge.Model.Orders.Events
{
    public class OrderedMembershipDomainEventHandler : INotificationHandler<OrderedMembershipDomainEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderedMembershipDomainEventHandler(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task Handle(OrderedMembershipDomainEvent orderStartedEvent, CancellationToken cancellationToken)
        {
            if (!orderStartedEvent.Order.Lines.Any(x => x.Product.Type == ProductType.BookClubMembership))
            {
                return;
            }

            var customer = await _customerRepository.FindByIdAsync(orderStartedEvent.CustomerId);
            customer.BookClubMember = true;
            customer.BookClubMemberUntil = DateTime.Now.AddMonths(1);

            _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
