using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Products;

namespace TaskableChallenge.Model.Orders
{
    public class OrderLine
    {
        public OrderLine(Order order, Product product, int quantity)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));
            OrderId = order.Id;
            Product = product ?? throw new ArgumentNullException(nameof(product));
            ProductId = product.Id;
            Quantity = quantity;
            TotalUnitPrice = Product.Price;
        }

        public int Id { get; protected set; }
        public int OrderId { get; protected set; }
        public Order Order { get; protected set; }
        public int ProductId { get; protected set; }
        public Product Product { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal TotalUnitPrice { get; protected set; }


    }
}
