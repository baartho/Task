using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Products;

namespace TaskableChallenge.Model.ShoppingCarts
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
