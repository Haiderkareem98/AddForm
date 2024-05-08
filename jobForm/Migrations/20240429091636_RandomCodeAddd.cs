using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobForm.Migrations
{
    /// <inheritdoc />
    public partial class RandomCodeAddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RandomCode",
                table: "Job",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandomCode",
                table: "Job");
        }
    }
}
