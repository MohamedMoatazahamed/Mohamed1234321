using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolsystem.Migrations
{
    /// <inheritdoc />
    public partial class Medo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gendrr",
                table: "Students",
                newName: "Gendr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gendr",
                table: "Students",
                newName: "Gendrr");
        }
    }
}
