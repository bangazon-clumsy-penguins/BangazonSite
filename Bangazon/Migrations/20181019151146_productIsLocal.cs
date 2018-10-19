using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class productIsLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", "0c795639-2d28-4ea9-aff5-3b9f12a9b059" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", "d3d58341-39f2-46b4-a9cd-d798a7b1fd62" });

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "IsLocal",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", 0, "27050923-9391-48ff-bb33-506a9e889916", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEB9BeTuevRlCK63jpbJPiKPuuAspzyvENa605MyqudKEP4XXem7SsXtDI7v1w5todg==", null, false, "3502e3e2-7de4-4489-b81d-cd2bf1ccc49a", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", 0, "400055a0-ede5-4972-9a23-e9ce6a70379e", "ladyface@faces.com", true, "April", "AwesomeLastName", false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAED5e8UIwfXcITAgmn3HU15r72DIv+Pn4wFkxJra2RpwHg0QOayI5lzUDdenNG66v2w==", null, false, "1c3695b4-2b30-4249-af93-da1483202fa5", "123 New Way", false, "LadyFace@Faces.com" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a1c29f2e-27ee-4156-bdc5-4d7366792363", "400055a0-ede5-4972-9a23-e9ce6a70379e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e732ca27-ffd7-4fd5-8452-1600bf3eb9eb", "27050923-9391-48ff-bb33-506a9e889916" });

            migrationBuilder.DropColumn(
                name: "IsLocal",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", 0, "0c795639-2d28-4ea9-aff5-3b9f12a9b059", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEG0a3YyOfwITZqOL+jEX5V/RzvqRkXQFe+jCTYHMBHzX72z8BvvY0jlHqnjJWvJD0Q==", null, false, "44b95608-95ef-4bdf-b023-de530788880a", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", 0, "d3d58341-39f2-46b4-a9cd-d798a7b1fd62", "ladyface@faces.com", true, "April", "AwesomeLastName", false, null, "LADYFACE@FACES.COM", "LADYFACE@FACES.COM", "AQAAAAEAACcQAAAAEMmJS6T/vePH8miL+pPOYF8O0+L2mcchLqi4md73eBimsPY8lxzDvpIaRGvhhaP39A==", null, false, "b4a87992-dd5f-4c9e-8136-118417bd0295", "123 New Way", false, "LadyFace@Faces.com" });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentType",
                keyColumn: "PaymentTypeId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "e2e6382f-083d-4fe2-9810-cfc57141462d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "ApplicationUserId", "DateCreated" },
                values: new object[] { "f0e3d034-8b36-42be-b29b-9448de7d9731", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
