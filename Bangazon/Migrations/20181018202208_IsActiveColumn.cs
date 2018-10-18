﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class IsActiveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.PaymentTypeId);
                    table.ForeignKey(
                        name: "FK_PaymentType_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    City = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 55, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentType",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", 0, "37e83a98-4a96-4258-909d-aa4caacb78fd", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEG1UnyyTx23luSYS/2D2fU2o6SZXQzv6ELbUm6Db6im5M3dagNYLgYEc40Hn326xEw==", null, false, "c46794b2-7c80-4773-a0fc-f7d84e8991cc", "123 Infinity Way", false, "admin@admin.com" },
                    { "aab8de96-b792-4e87-8d62-6be9e41142fa", 0, "13dda56c-8a02-4a0a-bc27-e73fec5877d5", "ladyface@faces.com", true, "April", "AwesomeLastName", false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAEA1HEhWlssssUrOYZ/y1SmF7W6ikbX3fPbA180ujMUHMG1q14MDThdlBSZzJ8h2ndw==", null, false, "f257eaf5-4a5c-49f1-ba93-cff7c501e9f5", "123 New Way", false, "LadyFace@Faces.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ProductTypeId", "Label" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Apple" },
                    { 3, "Phils SQL Training" },
                    { 4, "Adams socks" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "ApplicationUserId", "DateCompleted", "DateCreated", "PaymentTypeId" },
                values: new object[,]
                {
                    { 5, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", null, new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "aab8de96-b792-4e87-8d62-6be9e41142fa", null, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "PaymentTypeId", "AccountNumber", "ApplicationUserId", "DateCreated", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "86753095551212", "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Express", true },
                    { 2, "4102948572991", "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover", true },
                    { 3, "9992948572991", "aab8de96-b792-4e87-8d62-6be9e41142fa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover", true }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "ApplicationUserId", "City", "DateCreated", "Description", "Price", "ProductTypeId", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", "Poop Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 1", 10.0, 1, 3, "Product 1" },
                    { 5, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", "Chicago", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 5", 50.0, 1, 34, "Product 5" },
                    { 2, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", "Nashville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 2", 20.0, 2, 123, "Product 2" },
                    { 6, "aab8de96-b792-4e87-8d62-6be9e41142fa", "San Diego", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 6", 60.0, 2, 87, "Product 6" },
                    { 3, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", "Poop Town", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 3", 30.0, 3, 754, "Product 3" },
                    { 7, "aab8de96-b792-4e87-8d62-6be9e41142fa", "Denver", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 7", 70.0, 3, 7, "Product 7" },
                    { 4, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", "Nashville", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 4", 10.0, 4, 5, "Product 4" },
                    { 8, "aab8de96-b792-4e87-8d62-6be9e41142fa", "Los Angeles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of product 8", 80.0, 4, 10, "Product 8" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "ApplicationUserId", "DateCompleted", "DateCreated", "PaymentTypeId" },
                values: new object[,]
                {
                    { 1, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "7ac4dddd-bc4e-4d0b-bcae-6f76b161fa44", new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, "aab8de96-b792-4e87-8d62-6be9e41142fa", new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 6, 4, 2 },
                    { 7, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 7 },
                    { 5, 3, 8 },
                    { 3, 2, 6 },
                    { 4, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentTypeId",
                table: "Order",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_ApplicationUserId",
                table: "PaymentType",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ApplicationUserId",
                table: "Product",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}