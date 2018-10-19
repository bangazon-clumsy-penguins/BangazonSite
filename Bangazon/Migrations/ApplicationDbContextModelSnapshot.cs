﻿// <auto-generated />
using System;
using Bangazon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bangazon.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bangazon.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", AccessFailedCount = 0, ConcurrencyStamp = "27050923-9391-48ff-bb33-506a9e889916", Email = "admin@admin.com", EmailConfirmed = true, FirstName = "admin", LastName = "admin", LockoutEnabled = false, NormalizedEmail = "ADMIN@ADMIN.COM", NormalizedUserName = "ADMIN@ADMIN.COM", PasswordHash = "AQAAAAEAACcQAAAAEB9BeTuevRlCK63jpbJPiKPuuAspzyvENa605MyqudKEP4XXem7SsXtDI7v1w5todg==", PhoneNumberConfirmed = false, SecurityStamp = "3502e3e2-7de4-4489-b81d-cd2bf1ccc49a", StreetAddress = "123 Infinity Way", TwoFactorEnabled = false, UserName = "admin@admin.com" },
                        new { Id = "a1c29f2e-27ee-4156-bdc5-4d7366792363", AccessFailedCount = 0, ConcurrencyStamp = "400055a0-ede5-4972-9a23-e9ce6a70379e", Email = "ladyface@faces.com", EmailConfirmed = true, FirstName = "April", LastName = "AwesomeLastName", LockoutEnabled = false, NormalizedEmail = "LADYFACE@FACES.COM", NormalizedUserName = "LADYFACE@FACES.COM", PasswordHash = "AQAAAAEAACcQAAAAED5e8UIwfXcITAgmn3HU15r72DIv+Pn4wFkxJra2RpwHg0QOayI5lzUDdenNG66v2w==", PhoneNumberConfirmed = false, SecurityStamp = "1c3695b4-2b30-4249-af93-da1483202fa5", StreetAddress = "123 New Way", TwoFactorEnabled = false, UserName = "LadyFace@Faces.com" }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired();

                    b.Property<DateTime?>("DateCompleted");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("PaymentTypeId");

                    b.HasKey("OrderId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Order");

                    b.HasData(
                        new { OrderId = 1, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", DateCompleted = new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateCreated = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PaymentTypeId = 1 },
                        new { OrderId = 2, ApplicationUserId = "a1c29f2e-27ee-4156-bdc5-4d7366792363", DateCompleted = new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateCreated = new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PaymentTypeId = 3 },
                        new { OrderId = 3, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", DateCompleted = new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateCreated = new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), PaymentTypeId = 2 },
                        new { OrderId = 4, ApplicationUserId = "a1c29f2e-27ee-4156-bdc5-4d7366792363", DateCreated = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { OrderId = 5, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", DateCreated = new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");

                    b.HasData(
                        new { OrderProductId = 1, OrderId = 1, ProductId = 1 },
                        new { OrderProductId = 2, OrderId = 1, ProductId = 7 },
                        new { OrderProductId = 3, OrderId = 2, ProductId = 6 },
                        new { OrderProductId = 4, OrderId = 2, ProductId = 4 },
                        new { OrderProductId = 5, OrderId = 3, ProductId = 8 },
                        new { OrderProductId = 6, OrderId = 4, ProductId = 2 },
                        new { OrderProductId = 7, OrderId = 5, ProductId = 3 }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive");

                    b.HasKey("PaymentTypeId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("PaymentType");

                    b.HasData(
                        new { PaymentTypeId = 1, AccountNumber = "86753095551212", ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "American Express", IsActive = true },
                        new { PaymentTypeId = 2, AccountNumber = "4102948572991", ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Discover", IsActive = true },
                        new { PaymentTypeId = 3, AccountNumber = "9992948572991", ApplicationUserId = "a1c29f2e-27ee-4156-bdc5-4d7366792363", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Discover", IsActive = true }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired();

                    b.Property<string>("City");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsLocal");

                    b.Property<double>("Price");

                    b.Property<int>("ProductTypeId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("ProductId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");

                    b.HasData(
                        new { ProductId = 1, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", City = "Poop Town", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 1", IsLocal = false, Price = 10.0, ProductTypeId = 1, Quantity = 3, Title = "Product 1" },
                        new { ProductId = 2, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", City = "Nashville", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 2", IsLocal = false, Price = 20.0, ProductTypeId = 2, Quantity = 123, Title = "Product 2" },
                        new { ProductId = 3, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", City = "Poop Town", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 3", IsLocal = false, Price = 30.0, ProductTypeId = 3, Quantity = 754, Title = "Product 3" },
                        new { ProductId = 4, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", City = "Nashville", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 4", IsLocal = false, Price = 10.0, ProductTypeId = 4, Quantity = 5, Title = "Product 4" },
                        new { ProductId = 5, ApplicationUserId = "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", City = "Chicago", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 5", IsLocal = false, Price = 50.0, ProductTypeId = 1, Quantity = 34, Title = "Product 5" },
                        new { ProductId = 6, ApplicationUserId = "a1c29f2e-27ee-4156-bdc5-4d7366792363", City = "San Diego", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 6", IsLocal = false, Price = 60.0, ProductTypeId = 2, Quantity = 87, Title = "Product 6" },
                        new { ProductId = 7, ApplicationUserId = "a1c29f2e-27ee-4156-bdc5-4d7366792363", City = "Denver", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 7", IsLocal = false, Price = 70.0, ProductTypeId = 3, Quantity = 7, Title = "Product 7" },
                        new { ProductId = 8, ApplicationUserId = "a1c29f2e-27ee-4156-bdc5-4d7366792363", City = "Los Angeles", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Description of product 8", IsLocal = false, Price = 80.0, ProductTypeId = 4, Quantity = 10, Title = "Product 8" }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductType");

                    b.HasData(
                        new { ProductTypeId = 1, Label = "Food" },
                        new { ProductTypeId = 2, Label = "Apple" },
                        new { ProductTypeId = 3, Label = "Phils SQL Training" },
                        new { ProductTypeId = 4, Label = "Adams socks" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Orders")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon.Models.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId");
                });

            modelBuilder.Entity("Bangazon.Models.OrderProduct", b =>
                {
                    b.HasOne("Bangazon.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("PaymentTypes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Products")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
