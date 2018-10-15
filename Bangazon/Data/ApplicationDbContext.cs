using System;
using System.Collections.Generic;
using System.Text;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            // Restrict deletion of related order when OrderProducts entry is removed
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(l => l.Order)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            // Restrict deletion of related product when OrderProducts entry is removed
            modelBuilder.Entity<Product>()
                .HasMany(o => o.OrderProducts)
                .WithOne(l => l.Product)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentType>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");


            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "April",
                LastName = "AwesomeLastName",
                StreetAddress = "123 New Way",
                UserName = "LadyFace@Faces.com",
                NormalizedUserName = "LADYFACE@FACES.COM",
                Email = "ladyface@faces.com",
                NormalizedEmail = "LADYFACE@FACES.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash.HashPassword(user2, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType()
                {
                    PaymentTypeId = 1,
                    UserId = user.Id,
                    Description = "American Express",
                    AccountNumber = "86753095551212"
                },
                new PaymentType()
                {
                    PaymentTypeId = 2,
                    UserId = user.Id,
                    Description = "Discover",
                    AccountNumber = "4102948572991"
                },
                new PaymentType()
                {
                    PaymentTypeId = 3,
                    UserId = user2.Id,
                    Description = "Discover",
                    AccountNumber = "9992948572991"
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderId = 1,
                    DateCreated = new DateTime(2018, 9, 01),
                    DateCompleted = new DateTime(2018, 10, 01),
                    User = user,
                    PaymentTypeId = 1,
                },
                new Order()
                {
                    OrderId = 2,
                    DateCreated = new DateTime(2017, 3, 01),
                    DateCompleted = new DateTime(2018, 10, 01),
                    User = user2,
                    PaymentTypeId = 3,
                },
                new Order()
                {
                    OrderId = 3,
                    DateCreated = new DateTime(2016, 9, 01),
                    DateCompleted = new DateTime(2017, 10, 01),
                    User = user,
                    PaymentTypeId = 2,
                },
                new Order()
                {
                    OrderId = 4,
                    DateCreated = new DateTime(2018, 9, 01),
                    DateCompleted = null,
                    User = user2,
                    PaymentTypeId = null,
                },
                new Order()
                {
                    OrderId = 5,
                    DateCreated = new DateTime(2018, 10, 2),
                    DateCompleted = null,
                    User = user,
                    PaymentTypeId = null,
                }


            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                },
                new OrderProduct()
                {
                    OrderProductId = 2,
                    OrderId = 1,
                    ProductId = 7
                },
                new OrderProduct()
                {
                    OrderProductId = 3,
                    OrderId = 2,
                    ProductId = 6
                },
                new OrderProduct()
                {
                    OrderProductId = 4,
                    OrderId = 2,
                    ProductId = 4
                },
                new OrderProduct()
                {
                    OrderProductId = 5,
                    OrderId = 3,
                    ProductId = 8
                },
                new OrderProduct()
                {
                    OrderProductId = 6,
                    OrderId = 4,
                    ProductId = 2
                },
                new OrderProduct()
                {
                    OrderProductId = 7,
                    OrderId = 5,
                    ProductId = 3
                }
                );

        }

    }
}
