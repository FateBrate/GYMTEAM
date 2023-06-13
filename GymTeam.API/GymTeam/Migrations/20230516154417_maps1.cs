using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class maps1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "putanjaSlike",
                table: "Lokacija");

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "Lokacija",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "Lokacija",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<byte[]>(
                name: "slika",
                table: "Lokacija",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Lokacija");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Lokacija");

            migrationBuilder.DropColumn(
                name: "slika",
                table: "Lokacija");

            migrationBuilder.AddColumn<string>(
                name: "putanjaSlike",
                table: "Lokacija",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
