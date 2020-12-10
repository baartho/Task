using IdentityServer4.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;
using TaskableChallenge.Model.Orders;
using TaskableChallenge.Model.Products;
using TaskableChallenge.Model.ShippingSlips;
using TaskableChallenge.Model.Users;
using TaskableChallenge.Server.Infrastructure;
using TaskableChallenge.Server.Models;

namespace TaskableChallenge.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ShippingSlip> ShippingSlips { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, IMediator mediator) : base(options, operationalStoreOptions)
        {
            _mediator = mediator;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();
            await _mediator.DispatchDomainEventsAsync(this);
            return true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    string conn = "";

            //    optionsBuilder.UseSqlServer(conn);
            //}

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(ConfigureOrder);
            modelBuilder.Entity<Product>(ConfigureProduct);
            modelBuilder.Entity<ShippingSlip>(ConfigureShippingSlip);
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> entity)
        {
            entity.Property(x => x.CreateDateUtc).IsRequired();
            entity.Property(x => x.CustomerId).IsRequired();
            entity.Ignore(x => x.DomainEvents);

            entity.HasMany(y => y.Lines)
                .WithOne(y => y.Order)
                .HasForeignKey(x => x.OrderId)
                .Metadata.DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> entity)
        {
            entity.Property(x => x.Name).IsRequired();

            entity.Property(x => x.Type)
              .IsRequired()
              .HasConversion(
                  g => g.Value,
                  y => ProductType.Get(y));


        }

        private void ConfigureShippingSlip(EntityTypeBuilder<ShippingSlip> entity)
        {
            entity.Property(x => x.CreateDateUtc).IsRequired();
            entity.Property(x => x.CustomerId).IsRequired();
            entity.Ignore(x => x.DomainEvents);

            entity.HasMany(y => y.Lines)
                .WithOne(y => y.ShippingSlip)
                .HasForeignKey(x => x.ShippingSlipId)
                .Metadata.DependentToPrincipal.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
