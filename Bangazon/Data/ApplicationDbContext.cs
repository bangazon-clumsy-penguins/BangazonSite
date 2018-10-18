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
                Id = Guid.NewGuid().ToString(),   
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
                Id = Guid.NewGuid().ToString(),
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
            user2.PasswordHash = passwordHash2.HashPassword(user2, "Admin8!");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);


            ProductType ProductType1 = new ProductType()
            {
                ProductTypeId = 1,
                Label = "Food"
            };

            ProductType ProductType2 = new ProductType()
            {
                ProductTypeId = 2,
                Label = "Apple"
            };

            ProductType ProductType3 = new ProductType()
            {
                ProductTypeId = 3,
                Label = "Phils SQL Training"
            };

            ProductType ProductType4 = new ProductType()
            {
                ProductTypeId = 4,
                Label = "Adams socks"
            };

            modelBuilder.Entity<ProductType>().HasData(ProductType1);
            modelBuilder.Entity<ProductType>().HasData(ProductType2);
            modelBuilder.Entity<ProductType>().HasData(ProductType3);
            modelBuilder.Entity<ProductType>().HasData(ProductType4);


            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType() {
                    PaymentTypeId = 1,
                    IsActive = true,
                    ApplicationUserId = user.Id,
                    Description = "American Express",
                    AccountNumber = "86753095551212"
                },
                new PaymentType()
                {
                    PaymentTypeId = 2,
                    IsActive = true,
                    ApplicationUserId = user.Id,
                    Description = "Discover",
                    AccountNumber = "4102948572991"
                },
                new PaymentType()
                {
                    PaymentTypeId = 3,
                    IsActive = true,
                    ApplicationUserId = user2.Id,
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
                    ApplicationUserId = user.Id,
                    PaymentTypeId = 1
                },
                new Order()
                {
                    OrderId = 2,
                    DateCreated = new DateTime(2017, 3, 01),
                    DateCompleted = new DateTime(2018, 10, 01),
                    ApplicationUserId = user2.Id,
                    PaymentTypeId = 3
                },
                new Order()
                {
                    OrderId = 3,
                    DateCreated = new DateTime(2016, 9, 01),
                    DateCompleted = new DateTime(2017, 10, 01),
                    ApplicationUserId = user.Id,
                    PaymentTypeId = 2
                },
                new Order()
                {
                    OrderId = 4,
                    DateCreated = new DateTime(2018, 9, 01),
                    DateCompleted = null,
                    ApplicationUserId = user2.Id,
                    PaymentTypeId = null
                },
                new Order()
                {
                    OrderId = 5,
                    DateCreated = new DateTime(2018, 10, 2),
                    DateCompleted = null,
                    ApplicationUserId = user.Id,
                    PaymentTypeId = null
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
            Product product1 = new Product()
            {
                ProductId = 1,
                Description = "Description of product 1",
                City = "Poop Town",
                Title = "Product 1",
                Price = 10.00,
                ApplicationUserId = user.Id,
                ProductTypeId = 1,
                Quantity = 3
            };

            Product product2 = new Product()
            {
                ProductId = 2,
                Description = "Description of product 2",
                City = "Nashville",
                Title = "Product 2",
                Price = 20.00,
                ApplicationUserId = user.Id,
                ProductTypeId = 2,
                Quantity = 123
            };

            Product product3 = new Product()
            {
                ProductId = 3,
                Description = "Description of product 3",
                City = "Poop Town",
                Title = "Product 3",
                Price = 30.00,
                ApplicationUserId = user.Id,
                ProductTypeId = 3,
                Quantity = 754
            };

            Product product4 = new Product()
            {
                ProductId = 4,
                Description = "Description of product 4",
                City = "Nashville",
                Title = "Product 4",
                Price = 10.00,
                ApplicationUserId = user.Id,
                ProductTypeId = 4,
                Quantity = 5
            };

            Product product5 = new Product()
            {
                ProductId = 5,
                Description = "Description of product 5",
                City = "Chicago",
                Title = "Product 5",
                Price = 50.00,
                ApplicationUserId = user.Id,
                ProductTypeId = 1,
                Quantity = 34
            };

            Product product6 = new Product()
            {
                ProductId = 6,
                Description = "Description of product 6",
                City = "San Diego",
                Title = "Product 6",
                Price = 60.00,
                ApplicationUserId = user2.Id,
                ProductTypeId = 2,
                Quantity = 87
            };

            Product product7 = new Product()
            {
                ProductId = 7,
                Description = "Description of product 7",
                City = "Denver",
                Title = "Product 7",
                Price = 70.00,
                ApplicationUserId = user2.Id,
                ProductTypeId = 3,
                Quantity = 7
            };

            Product product8 = new Product()
            {
                ProductId = 8,
                Description = "Description of product 8",
                City = "Los Angeles",
                Title = "Product 8",
                Price = 80.00,
                ApplicationUserId = user2.Id,
                ProductTypeId = 4,
                Quantity = 10
            };

            modelBuilder.Entity<Product>().HasData(product1);
            modelBuilder.Entity<Product>().HasData(product2);
            modelBuilder.Entity<Product>().HasData(product3);
            modelBuilder.Entity<Product>().HasData(product4);
            modelBuilder.Entity<Product>().HasData(product5);
            modelBuilder.Entity<Product>().HasData(product6);
            modelBuilder.Entity<Product>().HasData(product7);
            modelBuilder.Entity<Product>().HasData(product8);

        }

    }
}
