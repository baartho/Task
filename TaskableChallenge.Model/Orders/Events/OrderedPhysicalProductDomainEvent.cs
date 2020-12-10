using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskableChallenge.Model.Orders.Events
{
    public class OrderedPhysicalProductDomainEvent : INotification
    {
        public int CustomerId { get; }
        public Order Order { get; }

        public OrderedPhysicalProductDomainEvent(Order order, int customerId)
        {
            Order = order;
            CustomerId = customerId;
        }
    }
}