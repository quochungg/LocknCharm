using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_PreMadeKeychains_PreMadeKeychainId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_PreMadeKeychainId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "PreMadeKeychainId",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Carts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "PreMadeKeychainId");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "f5677db5-b098-44c6-9a8f-e9954b53c8fd", new DateTime(2025, 6, 23, 16, 39, 29, 563, DateTimeKind.Utc).AddTicks(7893) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "3d385718-543c-44ce-95b1-a50860581583", new DateTime(2025, 6, 23, 16, 39, 29, 563, DateTimeKind.Utc).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 23, 16, 39, 29, 676, DateTimeKind.Utc).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 6, 23, 16, 39, 29, 676, DateTimeKind.Utc).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b299af1-89cf-482e-a21c-013205bbdc74", new DateTime(2025, 6, 23, 16, 39, 29, 563, DateTimeKind.Utc).AddTicks(8100), "AQAAAAIAAYagAAAAENOH4+Q7s/52SvxIKhM+N6UbdMoz7z3U6prPgblHn6l2Vhp6OGX3m3MjDb6D7NcpGQ==", "1ed22889-b505-4f82-8277-0e5e6bd8da2b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1fb8241-3134-486f-9ca7-6fc8e48fdc2b", new DateTime(2025, 6, 23, 16, 39, 29, 620, DateTimeKind.Utc).AddTicks(764), "AQAAAAIAAYagAAAAEGVAQX1+A5zPXqR6XV9bH+jzHGCemKivtp8gAhlqIWZ6CRiuowYFymXn4CqcS0btYw==", "81cc3438-44bc-4154-a419-908f16f68cb8" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PreMadeKeychainId",
                table: "CartItems",
                column: "PreMadeKeychainId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_PreMadeKeychains_PreMadeKeychainId",
                table: "CartItems",
                column: "PreMadeKeychainId",
                principalTable: "PreMadeKeychains",
                principalColumn: "Id");
        }
    }
}
