using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskableChallenge.Model.Orders;
using TaskableChallenge.Model.Orders.Commands;
using TaskableChallenge.Model.Orders.Infrastructure;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShippingSlips.Infrastructure;
using TaskableChallenge.Model.ShoppingCarts;
using TaskableChallenge.Model.Users;
using TaskableChallenge.Server.Models;
using TaskableChallenge.Shared;

namespace TaskableChallenge.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public TestController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<bool> AddBookClubMembership([FromServices] ICustomerRepository customerRepository, [FromServices] CreateOrderCommand createOrderCommand)
        {
            // basically preparing the data. Creating a customer and product.
            Customer cust1 = new Customer("Bartho");

            customerRepository.Add(cust1);
            await customerRepository.UnitOfWork.SaveEntitiesAsync();

            Product membership = new Product("Bookclub Membership", "Bookclub Membership", 20, ProductType.BookClubMembership);

            ShoppingCartItem item = new ShoppingCartItem();
            item.Quantity = 1;
            item.Product = membership;

            // Actual command
            var order = createOrderCommand.Execute(cust1.Id, new List<ShoppingCartItem> { item });

            return true;
        }

        [HttpGet("PurchasePhysicalProduct")]
        public async Task<bool> PurchasePhysicalProduct([FromServices] ICustomerRepository customerRepository, [FromServices] IShippingSlipRepository shippingSlipRepository, [FromServices] CreateOrderCommand createOrderCommand)
        {
            // basically preparing the data. Creating a customer and product.
            Customer cust1 = new Customer("Bartho");

            customerRepository.Add(cust1);
            await customerRepository.UnitOfWork.SaveEntitiesAsync();

            Product membership = new Product("Book", "Book", 20, ProductType.Book);

            ShoppingCartItem item = new ShoppingCartItem();
            item.Quantity = 1;
            item.Product = membership;

            // Actual command
            var order = await createOrderCommand.Execute(cust1.Id, new List<ShoppingCartItem> { item });

            var slip = await shippingSlipRepository.FindByOrderIdAsync(order.Id);

            return true;
        }
    }
}