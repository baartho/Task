using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskableChallenge.Model.Products
{
    public class Product
    {
        public Product(string name, string description, decimal price, ProductType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            if (price <= 0)
            {
                throw new ArgumentException(nameof(price));
            }
            Price = price;
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public ProductType Type { get; protected set; }
    }
}
