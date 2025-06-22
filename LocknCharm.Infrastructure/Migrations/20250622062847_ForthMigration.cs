using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "ClaimType",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "ClaimValue",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RoleClaims");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RoleClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "RoleClaims",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "RoleClaims",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedTime", "Name", "NormalizedName", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "0b5560e5-1736-4cd3-af0e-e94766a08d37", new DateTime(2025, 6, 22, 6, 28, 47, 475, DateTimeKind.Utc).AddTicks(2019), "admin", "ADMIN", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "7267a43b-5c37-4311-99fc-dcc054fc17a6", new DateTime(2025, 6, 22, 6, 28, 47, 475, DateTimeKind.Utc).AddTicks(2022), "user", "USER", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedTime", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), 0, "4fc974ae-cc09-429c-b77f-45c14432aa7a", new DateTime(2025, 6, 22, 6, 28, 47, 475, DateTimeKind.Utc).AddTicks(2168), "admin@example.com", true, null, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAENSlgH1NWda1Wi2lRBtBXdzqXS28xzJ4Sp9NR43sI6phHd+OQTwLPU1IfepHMCtQCw==", null, false, "18d406e1-5af2-4fb9-922a-c7ef944a6a73", false, null, "admin" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 0, "41baa205-bdfd-4ed4-aad0-16fbbc8d8d1a", new DateTime(2025, 6, 22, 6, 28, 47, 532, DateTimeKind.Utc).AddTicks(4164), "user1@example.com", true, "Application", "User", false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEGdYHdhSDKpkbxhVzZQfba2wTTUDt/qP0b600dH17NC3hNeUuvFyFM1wdUvN3qe2Dg==", null, false, "2bbaadc2-78bb-4f04-b138-36efd450de99", false, null, "user1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedTime", "UpdatedTime" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 6, 22, 6, 28, 47, 589, DateTimeKind.Utc).AddTicks(1372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 6, 22, 6, 28, 47, 589, DateTimeKind.Utc).AddTicks(1373), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_AspNetRoleClaims_Id",
                table: "RoleClaims",
                column: "Id",
                principalTable: "AspNetRoleClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetUserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_AspNetRoleClaims_Id",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetUserRoles_UserId_RoleId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "RoleClaims");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "RoleClaims");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RoleClaims",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ClaimType",
                table: "RoleClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClaimValue",
                table: "RoleClaims",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "RoleClaims",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
