using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "16bf8459-e4fb-4919-8d56-6257db7c91dc", new DateTime(2025, 7, 1, 12, 42, 6, 995, DateTimeKind.Utc).AddTicks(8798) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "f6de273a-aa73-4d40-8c26-099231a97a07", new DateTime(2025, 7, 1, 12, 42, 6, 995, DateTimeKind.Utc).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 1, 12, 42, 7, 111, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 1, 12, 42, 7, 111, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f13a55d-a521-4494-b115-96cbe531b059", new DateTime(2025, 7, 1, 12, 42, 6, 995, DateTimeKind.Utc).AddTicks(8936), "AQAAAAIAAYagAAAAEOfCnRyGREk7YAAw4Ctn3t8/Y/Z86rb0fCUUrbxpxgSEZPNdsS+fXqbC6FjZxW0LWQ==", "d9154144-f056-417d-8d82-89bb2ef3bdcd" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b3d6d3e-5318-4f3b-9f29-3b9d2e873ed6", new DateTime(2025, 7, 1, 12, 42, 7, 53, DateTimeKind.Utc).AddTicks(5325), "AQAAAAIAAYagAAAAEAXsczh/8QLS/nZrvuE8NXWws4X+fyVrvf+OdQ5dA2GjTOxN/Lz9DV9oVNndblXXzw==", "d4abba1d-e0fa-424c-8d5e-84bb274c846d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "934f0b0b-2f37-42df-8333-ec20c892506c", new DateTime(2025, 7, 1, 12, 30, 48, 226, DateTimeKind.Utc).AddTicks(5996) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "4cf23d1c-0a7d-4c83-a263-95388a4a4971", new DateTime(2025, 7, 1, 12, 30, 48, 226, DateTimeKind.Utc).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 1, 12, 30, 48, 341, DateTimeKind.Utc).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 1, 12, 30, 48, 341, DateTimeKind.Utc).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90a131f-ab25-42ac-8648-867665002155", new DateTime(2025, 7, 1, 12, 30, 48, 226, DateTimeKind.Utc).AddTicks(6173), "AQAAAAIAAYagAAAAEAbJZF3aBB2FNQDz8tuVhDXcCWgJ+SZ4JMRgMlnvk8xS5SYQDnNEtg8tuE/MIlit6w==", "a6ce20c6-82f4-4755-8c28-5711d93a6188" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3732200-aaa1-4f0f-ae14-f37c322a1802", new DateTime(2025, 7, 1, 12, 30, 48, 284, DateTimeKind.Utc).AddTicks(2823), "AQAAAAIAAYagAAAAEGi7JsH0shFDsNEgEyRMw8RRhOE2DeFZyuP+PinBiZOn9llfGfFgzzsTPttUlkFaFQ==", "34e17206-1536-43d7-8713-f80b6db83afb" });
        }
    }
}
