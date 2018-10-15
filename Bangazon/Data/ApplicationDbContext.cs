using System;
using System.Collections.Generic;
using System.Text;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Order> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            // Restrict deletion of related order when OrderProducts entry is removed
            modelBuilder.Entity<Order> ()
                .HasMany (o => o.OrderProducts)
                .WithOne (l => l.Order)
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<Product> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            // Restrict deletion of related product when OrderProducts entry is removed
            modelBuilder.Entity<Product> ()
                .HasMany (o => o.OrderProducts)
                .WithOne (l => l.Product)
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentType> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");


            ApplicationUser user = new ApplicationUser {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid ().ToString ("D")
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

            var passwordHash = new PasswordHasher<ApplicationUser> ();
            user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
            modelBuilder.Entity<ApplicationUser> ().HasData (user);

            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash.HashPassword(user2, "Admin8*");
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

            modelBuilder.Entity<ApplicationUser>().HasData(ProductType1);
            modelBuilder.Entity<ApplicationUser>().HasData(ProductType2);
            modelBuilder.Entity<ApplicationUser>().HasData(ProductType3);
            modelBuilder.Entity<ApplicationUser>().HasData(ProductType4);


            modelBuilder.Entity<PaymentType> ().HasData (
                new PaymentType() {
                    PaymentTypeId = 1,
                    UserId = user.Id,
                    Description = "American Express",
                    AccountNumber = "86753095551212"
                },
                new PaymentType() {
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

            Product product1 = new Product()
            {
                Description = "Description of product 1",
                Title = "Product 1",
                Price = 10.00,
                User = user,
                ProductTypeId = 1,
                ProductType = ProductType1
            };

            Product product2 = new Product()
            {
                Description = "Description of product 2",
                Title = "Product 2",
                Price = 20.00,
                User = user,
                ProductTypeId = 2,
                ProductType = ProductType2
            };

            Product product3 = new Product()
            {
                Description = "Description of product 3",
                Title = "Product 3",
                Price = 30.00,
                User = user,
                ProductTypeId = 3,
                ProductType = ProductType3
            };

            Product product4 = new Product()
            {
                Description = "Description of product 4",
                Title = "Product 4",
                Price = 10.00,
                User = user,
                ProductTypeId = 4,
                ProductType = ProductType4
            };

            Product product5 = new Product()
            {
                Description = "Description of product 5",
                Title = "Product 5",
                Price = 50.00,
                User = user,
                ProductTypeId = 1,
                ProductType = ProductType1
            };

            Product product6 = new Product()
            {
                Description = "Description of product 6",
                Title = "Product 6",
                Price = 60.00,
                User = user,
                ProductTypeId = 2,
                ProductType = ProductType2
            };

            Product product7 = new Product()
            {
                Description = "Description of product 7",
                Title = "Product 7",
                Price = 70.00,
                User = user,
                ProductTypeId = 3,
                ProductType = ProductType3
            };

            Product product8 = new Product()
            {
                Description = "Description of product 8",
                Title = "Product 8",
                Price = 80.00,
                User = user,
                ProductTypeId = 4,
                ProductType = ProductType4
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