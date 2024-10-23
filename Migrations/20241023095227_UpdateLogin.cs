using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreFinalApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Candidates",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Candidates");
        }
    }
}
