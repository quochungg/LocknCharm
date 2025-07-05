using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "6371a644-7179-4a29-9a0b-49711dbf12e2", new DateTime(2025, 7, 5, 2, 37, 25, 243, DateTimeKind.Utc).AddTicks(3871) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "eda6e1bc-bf40-480b-a210-c03a5642fbd5", new DateTime(2025, 7, 5, 2, 37, 25, 243, DateTimeKind.Utc).AddTicks(3874) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 5, 2, 37, 25, 358, DateTimeKind.Utc).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 5, 2, 37, 25, 358, DateTimeKind.Utc).AddTicks(4162));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e77fa111-6bba-4aa3-b5a2-5674ecb35ced", new DateTime(2025, 7, 5, 2, 37, 25, 243, DateTimeKind.Utc).AddTicks(4035), "AQAAAAIAAYagAAAAEI/uzooNetEto9BZgUShIihHpL0dxG2SN5U+mNqyLVc2RcJS8g6Szdtb/kOE4XKXXQ==", "21a91b86-4210-4160-abd1-f129b4297e48" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3ddf704-5412-4f8e-81ec-1519045ae80e", new DateTime(2025, 7, 5, 2, 37, 25, 300, DateTimeKind.Utc).AddTicks(4955), "AQAAAAIAAYagAAAAEFUP9rUPazKKVPql6kUCjcWKrCDCd12WIMtx7u2fOblSJeDzmK4GUYe2dlaCCBHAhw==", "d25ee2b0-4a98-4325-9ebe-539abed3b433" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

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
    }
}
