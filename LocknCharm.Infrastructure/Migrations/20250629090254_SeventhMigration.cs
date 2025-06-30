using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreMadeKeychains_Categories_CategoryId",
                table: "PreMadeKeychains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreMadeKeychains",
                table: "PreMadeKeychains");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PreMadeKeychains");

            migrationBuilder.RenameTable(
                name: "PreMadeKeychains",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Product",
                newName: "UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_PreMadeKeychains_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AddColumn<decimal>(
                name: "CartTotalPrice",
                table: "Carts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CartItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "CartItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Product",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Product",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Product",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Product",
                type: "integer",
                nullable: true);

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
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CartTotalPrice",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "PreMadeKeychains");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PreMadeKeychains",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "PreMadeKeychains",
                newName: "IX_PreMadeKeychains_CategoryId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "CartItems",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "PreMadeKeychains",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PreMadeKeychains",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "PreMadeKeychains",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PreMadeKeychains",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreMadeKeychains",
                table: "PreMadeKeychains",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "7c4c188b-babb-457c-99ab-9277213a97b6", new DateTime(2025, 6, 28, 12, 28, 5, 296, DateTimeKind.Utc).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "c10e98fb-f2a9-4b43-97f9-e388910042fe", new DateTime(2025, 6, 28, 12, 28, 5, 296, DateTimeKind.Utc).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 28, 12, 28, 5, 410, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 28, 12, 28, 5, 410, DateTimeKind.Utc).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4fd5297-4e8c-4924-8a5f-329990c0ec37", new DateTime(2025, 6, 28, 12, 28, 5, 296, DateTimeKind.Utc).AddTicks(8385), "AQAAAAIAAYagAAAAEH8ZmDvSebtfUbDQnXu0K9Qr88C3y6/CMoPRaFFwSODW7ChN4BkI+ztFNz129uc/pA==", "0bbcea68-a1c4-4ed4-bd6d-6fd091e1c852" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c59d5c19-ea4a-4f37-ba39-e7aadd66b3d7", new DateTime(2025, 6, 28, 12, 28, 5, 353, DateTimeKind.Utc).AddTicks(6141), "AQAAAAIAAYagAAAAEARCJWdA2r/ZCbLLcVqkeNy2MepLhrdDClzY9WynjQC2P49FG95Wno9Xq607raPZmQ==", "7e91158c-f29b-4fda-9546-5b52107736a2" });

            migrationBuilder.AddForeignKey(
                name: "FK_PreMadeKeychains_Categories_CategoryId",
                table: "PreMadeKeychains",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
