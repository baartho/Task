using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskableChallenge.Model.Orders.Infrastructure;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShippingSlips;
using TaskableChallenge.Model.ShippingSlips.Infrastructure;
using TaskableChallenge.Model.Users;

namespace TaskableChallenge.Model.Orders.Events
{
    public class OrderedPhysicalProductDomainEventHandler : INotificationHandler<OrderedPhysicalProductDomainEvent>
    {
        private readonly IShippingSlipRepository _shippingSlipRepository;

        public OrderedPhysicalProductDomainEventHandler(IShippingSlipRepository shippingSlipRepository)
        {
            _shippingSlipRepository = shippingSlipRepository ?? throw new ArgumentNullException(nameof(shippingSlipRepository));
        }

        public async Task Handle(OrderedPhysicalProductDomainEvent orderEvent, CancellationToken cancellationToken)
        {
            if (!orderEvent.Order.Lines.Any(x => x.Product.Type == ProductType.Book || x.Product.Type == ProductType.Video))
            {
                return;
            }

            ShippingSlip shippingSlip = new ShippingSlip(orderEvent.CustomerId, "Street 1, 123", orderEvent.Order);
            _shippingSlipRepository.Add(shippingSlip);
            await _shippingSlipRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
