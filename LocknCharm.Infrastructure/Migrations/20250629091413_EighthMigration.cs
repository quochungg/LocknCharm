using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EighthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PreMadeKeychains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreMadeKeychains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreMadeKeychains_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreMadeKeychains_Products_Id",
                        column: x => x.Id,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "3c7c73c4-556a-4239-bf1d-82bfa2ae2eaf", new DateTime(2025, 6, 29, 9, 14, 12, 777, DateTimeKind.Utc).AddTicks(5663) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "347f7c31-a51b-4542-a9b4-dcaff4d12aff", new DateTime(2025, 6, 29, 9, 14, 12, 777, DateTimeKind.Utc).AddTicks(5666) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 29, 9, 14, 12, 891, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 29, 9, 14, 12, 891, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e57497c-9071-4cf5-b622-1bf524af4aa4", new DateTime(2025, 6, 29, 9, 14, 12, 777, DateTimeKind.Utc).AddTicks(5825), "AQAAAAIAAYagAAAAEB3WP38S9Pqe2u3EAMOd/3+boccYrYjkVmafwWP6IGsVJwYXRmebCfQz3nhLbBTwGw==", "1adf2777-d5b5-4917-8b7f-0691942690ad" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efe67c87-d6c6-4593-b69b-362417828b5f", new DateTime(2025, 6, 29, 9, 14, 12, 834, DateTimeKind.Utc).AddTicks(6073), "AQAAAAIAAYagAAAAENPCRHXXMYT53Ck3r8W1KFIpfNmwEBa+lZz4r0k5MVGQPtI1rypacXTiAEBnp/Q2GQ==", "34cc4747-6a0e-48fa-b04c-1628bbb73ff5" });

            migrationBuilder.CreateIndex(
                name: "IX_PreMadeKeychains_CategoryId",
                table: "PreMadeKeychains",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "PreMadeKeychains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Product",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "ad44d489-0dc6-4264-a726-a2d32549f9ea", new DateTime(2025, 6, 29, 9, 2, 53, 755, DateTimeKind.Utc).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "5781cbf9-fd32-4bdf-a8cc-fb1526040956", new DateTime(2025, 6, 29, 9, 2, 53, 755, DateTimeKind.Utc).AddTicks(4045) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 29, 9, 2, 53, 868, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 29, 9, 2, 53, 868, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e641383-f044-4c1e-b8be-de345bd1c2e4", new DateTime(2025, 6, 29, 9, 2, 53, 755, DateTimeKind.Utc).AddTicks(4200), "AQAAAAIAAYagAAAAEOjGcF0oHRCtycHvpSHey930WVa54Bhxq3GTzyoJvoq9D2jp1XolRb8+1gO41e1WdA==", "07204622-dce6-4353-afc3-214e648b2372" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef06a52-ea84-4a45-81c8-753ebba37810", new DateTime(2025, 6, 29, 9, 2, 53, 811, DateTimeKind.Utc).AddTicks(7255), "AQAAAAIAAYagAAAAEFDeoLDpPPgvQn3dNoEh/B7/islqCO5DNxI8p22N/6ISrXPlTyhtcWe0LD9HPdDqSA==", "9b14c619-8df2-4aa2-bb14-7bc797dc744e" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
