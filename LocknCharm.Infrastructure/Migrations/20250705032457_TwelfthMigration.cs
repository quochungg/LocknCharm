using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TwelfthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DeliveryDetail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "087a9449-ed35-469c-a713-37dc92b103c3", new DateTime(2025, 7, 5, 3, 24, 56, 726, DateTimeKind.Utc).AddTicks(7026) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "7c03b581-74bb-4ab9-ab05-278f1d300020", new DateTime(2025, 7, 5, 3, 24, 56, 726, DateTimeKind.Utc).AddTicks(7029) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 5, 3, 24, 56, 840, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 5, 3, 24, 56, 840, DateTimeKind.Utc).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "891396b0-424b-4080-bf50-25abbb86fe37", new DateTime(2025, 7, 5, 3, 24, 56, 726, DateTimeKind.Utc).AddTicks(7210), "AQAAAAIAAYagAAAAEAGGA0zn8K3UC141II+6mo3xC8IYilkg78uEcIHK64uSr3E3F1DXuGzXDNiepFA5eg==", "f553fa64-c374-4224-972a-405109264873" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce34abda-f35b-4f2b-ae06-381eade79546", new DateTime(2025, 7, 5, 3, 24, 56, 783, DateTimeKind.Utc).AddTicks(3487), "AQAAAAIAAYagAAAAEMy0LHZoArYeAVbirn4VQOUsOxfd3cPEClmqVFf8b2mZDKKw2ryHTpZZbw2WlCSnlw==", "cce74a35-ef62-428e-b00f-8327cfbb6781" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DeliveryDetail");

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
        }
    }
}
