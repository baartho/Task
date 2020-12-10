using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShoppingCarts;
using TaskableChallenge.Model.Orders;
using TaskableChallenge.Model.Users;

namespace TaskableChallenge.Model.ShippingSlips
{
    public class ShippingSlip : Entity
    {
        private ShippingSlip()
        {
            _lines = new HashSet<ShippingSlipLine>();
        }

        public ShippingSlip(int customerId, string address, Order order)
        {
            _lines = new HashSet<ShippingSlipLine>();
            CustomerId = customerId;
            if (order.Lines == null || order.Lines.Count == 0)
            {
                throw new ArgumentNullException(nameof(order.Lines));
            }
            OrderId = order.Id;
            AddLines(order.Lines.ToList());
            Address = address;
            CreateDateUtc = DateTime.UtcNow;
        }

        private void AddLines(List<OrderLine> lines)
        {
            foreach (var item in lines.Where(x => x.Product.Type == ProductType.Book || x.Product.Type == ProductType.Video))
            {
                _lines.Add(new ShippingSlipLine(this, item.Product, item.Quantity));
            }
        }

        public int Id { get; protected set; }
        public int CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime CreateDateUtc { get; protected set; }
        private readonly HashSet<ShippingSlipLine> _lines;
        public IReadOnlyCollection<ShippingSlipLine> Lines => _lines;
        public string Address { get; set; }
        //public string City { get; set; } // Ommited properties for brevity
        //public string State { get; set; }
        //public string ZipCode { get; set; }


    }
}
