using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskableChallenge.Model.Orders.Events
{
    public class OrderedMembershipDomainEvent : INotification
    {
        public int CustomerId { get; }
        public Order Order { get; }

        public OrderedMembershipDomainEvent(Order order, int customerId)
        {
            Order = order;
            CustomerId = customerId;
        }
    }
}