using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFinalApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateCompanyRoleToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Candidates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Candidates");
        }
    }
}
