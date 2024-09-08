using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Infrastructure.Persistences.Migrations
{
    public partial class Alter_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditCreateDate",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuditCreateUser",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuditDeleteDate",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuditDeleteUser",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuditUpdateDate",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuditUpdateUser",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "MyPortafolio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchOfficeId",
                schema: "MyPortafolio",
                table: "UserRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AuditCreateDate",
                schema: "MyPortafolio",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AuditCreateUser",
                schema: "MyPortafolio",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditDeleteDate",
                schema: "MyPortafolio",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AuditDeleteUser",
                schema: "MyPortafolio",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuditUpdateDate",
                schema: "MyPortafolio",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditUpdateUser",
                schema: "MyPortafolio",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                schema: "MyPortafolio",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchOfficeId",
                schema: "MyPortafolio",
                table: "UserRoles",
                type: "int",
                nullable: true);
        }
    }
}
