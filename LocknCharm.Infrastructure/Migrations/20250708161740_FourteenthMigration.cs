using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FourteenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Payments",
                newName: "TransactionDateTime");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Payments",
                newName: "Signature");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentLinkId",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "Payments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql(
                "ALTER TABLE \"Payments\" ALTER COLUMN \"OrderCode\" TYPE bigint USING \"OrderCode\"::bigint;"
            );

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f90"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f90a1"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f90a1b2"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f90a1b2c3"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "51cf62d5-1aa4-4cc4-aa51-19c5f5df514f", new DateTime(2025, 7, 8, 16, 17, 39, 217, DateTimeKind.Utc).AddTicks(1207) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "8c936916-feb1-4287-ab95-c1a5477c78a6", new DateTime(2025, 7, 8, 16, 17, 39, 217, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 8, 16, 17, 39, 350, DateTimeKind.Utc).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45b9a6d3-a9bc-465c-930b-bb48c8007073", new DateTime(2025, 7, 8, 16, 17, 39, 217, DateTimeKind.Utc).AddTicks(1391), "AQAAAAIAAYagAAAAEMDjrSU/gBhpe+gjx5IWoNnSTdWcPf+GYYt0geabIDvKHDLvasArXjb7JCJG5SZI1w==", "a2c9d79d-2b8e-4647-8f46-549dbd65077c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "663cac93-68c8-433f-b2a1-a58e43d61a1e", new DateTime(2025, 7, 8, 16, 17, 39, 282, DateTimeKind.Utc).AddTicks(7011), "AQAAAAIAAYagAAAAEL+lwndX+/NIK00pEEpuXhwMeSmno1vyueX7qHz1IDaOe0ZcHd81ddfJ5T6Xrv6UeA==", "43cba068-41ac-4bc3-ba37-8f8a41cf8d09" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentLinkId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "TransactionDateTime",
                table: "Payments",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "Signature",
                table: "Payments",
                newName: "Status");

            migrationBuilder.Sql(
                "ALTER TABLE \"Payments\" ALTER COLUMN \"OrderCode\" TYPE integer USING \"OrderCode\"::integer;"
            );

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f90"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f90a1"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f90a1b2"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f90a1b2c3"),
                column: "CreatedDate",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "5abe826e-3ed4-44c8-a3bb-a3c9b8f61513", new DateTime(2025, 7, 7, 5, 53, 2, 222, DateTimeKind.Utc).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime" },
                values: new object[] { "6a23bf10-08de-4e0b-8b51-1197c039ec03", new DateTime(2025, 7, 7, 5, 53, 2, 222, DateTimeKind.Utc).AddTicks(7887) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") },
                column: "CreatedTime",
                value: new DateTime(2025, 7, 7, 5, 53, 2, 336, DateTimeKind.Utc).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb7db36-1baa-46b5-b9af-8ac486830ec3", new DateTime(2025, 7, 7, 5, 53, 2, 222, DateTimeKind.Utc).AddTicks(8046), "AQAAAAIAAYagAAAAEKPMOeZqZ20n4twCeYFV58vO+hwoYvcQMs+jMpUbQwJ2BTWbp9tAcRb20PY4z6d0ng==", "1a7f6b74-06ba-44fd-8e17-4f32dc4c4af9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b8fd8d1-8179-4aff-b446-8c0ae8819abb", new DateTime(2025, 7, 7, 5, 53, 2, 279, DateTimeKind.Utc).AddTicks(3491), "AQAAAAIAAYagAAAAEKy7lUPzF9l3JA2lggvoag/ZEq+xy4qHaDLAKu2OeypYeuBJsn4O5Bdx3S4rNMAIVA==", "8502e136-aabb-4577-bbf8-fa97802b44fd" });
        }
    }
}
