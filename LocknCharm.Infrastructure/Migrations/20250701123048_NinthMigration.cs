using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NinthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryDetailId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DeliveryDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDetail_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryDetailId",
                table: "Orders",
                column: "DeliveryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetail_UserId",
                table: "DeliveryDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryDetail_DeliveryDetailId",
                table: "Orders",
                column: "DeliveryDetailId",
                principalTable: "DeliveryDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryDetail_DeliveryDetailId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryDetail");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryDetailId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryDetailId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
