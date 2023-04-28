using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class photo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "slika",
                table: "Obavijest",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika",
                table: "Obavijest");
        }
    }
}
