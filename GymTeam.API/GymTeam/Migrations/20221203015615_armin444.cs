using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class armin444 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivatniTrener_PrivatniTrener_privatniTrenerid",
                table: "PrivatniTrener");

            migrationBuilder.DropIndex(
                name: "IX_PrivatniTrener_privatniTrenerid",
                table: "PrivatniTrener");

            migrationBuilder.DropColumn(
                name: "privatniTrenerID",
                table: "PrivatniTrener");

            migrationBuilder.DropColumn(
                name: "privatniTrenerid",
                table: "PrivatniTrener");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "privatniTrenerID",
                table: "PrivatniTrener",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "privatniTrenerid",
                table: "PrivatniTrener",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrivatniTrener_privatniTrenerid",
                table: "PrivatniTrener",
                column: "privatniTrenerid");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivatniTrener_PrivatniTrener_privatniTrenerid",
                table: "PrivatniTrener",
                column: "privatniTrenerid",
                principalTable: "PrivatniTrener",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
