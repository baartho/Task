using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;
using TaskableChallenge.Model.Orders.Events;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShoppingCarts;

namespace TaskableChallenge.Model.Orders
{
    public class Order : Entity
    {
        private Order()
        {
            _lines = new HashSet<OrderLine>();
        }

        public Order(int customerId, List<ShoppingCartItem> items)
        {
            _lines = new HashSet<OrderLine>();
            CustomerId = customerId;
            if (items == null || items.Count == 0)
            {
                throw new ArgumentNullException(nameof(items));
            }
            AddItems(items);
            TotalPrice = Lines.Sum(x => x.TotalUnitPrice * x.Quantity);
            CreateDateUtc = DateTime.UtcNow;
        }

        private void AddItems(List<ShoppingCartItem> items)
        {
            foreach (var item in items)
            {
                _lines.Add(new OrderLine(this, item.Product, item.Quantity));
            }
        }

        public void Purchase()
        {
            if (Lines.Any(x => x.Product.Type == ProductType.BookClubMembership))
            {
                var orderedMembershipDomainEvent = new OrderedMembershipDomainEvent(this, CustomerId);
                this.AddDomainEvent(orderedMembershipDomainEvent);
            }

            if (Lines.Any(x => x.Product.Type == ProductType.Book || x.Product.Type == ProductType.Video))
            {
                var orderedPhysicalProductDomainEvent = new OrderedPhysicalProductDomainEvent(this, CustomerId);
                this.AddDomainEvent(orderedPhysicalProductDomainEvent);
            }
        }

        public int Id { get; protected set; }
        public int CustomerId { get; protected set; }
        public DateTime CreateDateUtc { get; protected set; }
        private readonly HashSet<OrderLine> _lines;
        public IReadOnlyCollection<OrderLine> Lines => _lines;
        public decimal TotalPrice { get; protected set; }


    }
}
