using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShippingSlips;

namespace TaskableChallenge.Model.Orders
{
    public class ShippingSlipLine
    {
        private ShippingSlipLine()
        {

        }

        public ShippingSlipLine(ShippingSlip shipping, Product product, int quantity)
        {
            ShippingSlip = shipping ?? throw new ArgumentNullException(nameof(shipping));
            ShippingSlipId = shipping.Id;
            Product = product ?? throw new ArgumentNullException(nameof(product));
            ProductId = product.Id;
            Quantity = quantity;
        }

        public int Id { get; protected set; }
        public int ShippingSlipId { get; protected set; }
        public ShippingSlip ShippingSlip { get; protected set; }
        public int ProductId { get; protected set; }
        public Product Product { get; protected set; }
        public int Quantity { get; protected set; }
    }
}
