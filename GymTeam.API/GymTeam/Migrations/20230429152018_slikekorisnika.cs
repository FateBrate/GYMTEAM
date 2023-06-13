using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class slikekorisnika : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videozapis");

            migrationBuilder.DropColumn(
                name: "putanjaSlike",
                table: "Korisnik");

            migrationBuilder.AddColumn<byte[]>(
                name: "slika",
                table: "Korisnik",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slika",
                table: "Korisnik");

            migrationBuilder.AddColumn<string>(
                name: "putanjaSlike",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Videozapis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trajanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    videoTreningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videozapis", x => x.id);
                    table.ForeignKey(
                        name: "FK_Videozapis_VideoTrening_videoTreningId",
                        column: x => x.videoTreningId,
                        principalTable: "VideoTrening",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videozapis_videoTreningId",
                table: "Videozapis",
                column: "videoTreningId");
        }
    }
}
