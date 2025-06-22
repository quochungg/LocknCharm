using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocknCharm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Users",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Users",
                newName: "CreatedTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Users",
                newName: "CreatedAt");
        }
    }
}
