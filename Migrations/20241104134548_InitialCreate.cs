using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFinalApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Candidates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Candidates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Candidates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Candidates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Candidates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Candidates",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Candidates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Candidates",
                type: "TEXT",
                nullable: true);
        }
    }
}
