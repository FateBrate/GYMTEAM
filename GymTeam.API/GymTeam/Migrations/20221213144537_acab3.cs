using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class acab3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                table: "ClanarinaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                table: "ClanarinaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Adresa_adresaID",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Role_roleId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_Adresa_adresaId",
                table: "Lokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_korisnikID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaPlacanje_Narudzba_narudzbaID",
                table: "NarudzbaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaPlacanje_Placanje_placanjeID",
                table: "NarudzbaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PlanIshrane_planIshraneID",
                table: "planIshrane_PrehrambeniArtikal");

            migrationBuilder.DropForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PrehrambeniArtikal_prehrambeniArtikalID",
                table: "planIshrane_PrehrambeniArtikal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktNarudzba_Narudzba_narudzbaID",
                table: "ProduktNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktNarudzba_Produkt_produktID",
                table: "ProduktNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Korisnik_korisnikId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Lokacija_lokacijaId",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Rezervacija_rezervacijaId",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Videozapis_VideoTrening_videoTreningId",
                table: "Videozapis");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datumRodjenja",
                table: "Korisnik",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "putanjaSlike",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                table: "ClanarinaPlacanje",
                column: "clanarinaID",
                principalTable: "Clanarina",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                table: "ClanarinaPlacanje",
                column: "placanjeID",
                principalTable: "Placanje",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Adresa_adresaID",
                table: "Korisnik",
                column: "adresaID",
                principalTable: "Adresa",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Role_roleId",
                table: "Korisnik",
                column: "roleId",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacija_Adresa_adresaId",
                table: "Lokacija",
                column: "adresaId",
                principalTable: "Adresa",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_korisnikID",
                table: "Narudzba",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaPlacanje_Narudzba_narudzbaID",
                table: "NarudzbaPlacanje",
                column: "narudzbaID",
                principalTable: "Narudzba",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaPlacanje_Placanje_placanjeID",
                table: "NarudzbaPlacanje",
                column: "placanjeID",
                principalTable: "Placanje",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PlanIshrane_planIshraneID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "planIshraneID",
                principalTable: "PlanIshrane",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PrehrambeniArtikal_prehrambeniArtikalID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "prehrambeniArtikalID",
                principalTable: "PrehrambeniArtikal",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktNarudzba_Narudzba_narudzbaID",
                table: "ProduktNarudzba",
                column: "narudzbaID",
                principalTable: "Narudzba",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktNarudzba_Produkt_produktID",
                table: "ProduktNarudzba",
                column: "produktID",
                principalTable: "Produkt",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Korisnik_korisnikId",
                table: "Rezervacija",
                column: "korisnikId",
                principalTable: "Korisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Lokacija_lokacijaId",
                table: "Termin",
                column: "lokacijaId",
                principalTable: "Lokacija",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Rezervacija_rezervacijaId",
                table: "Termin",
                column: "rezervacijaId",
                principalTable: "Rezervacija",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Videozapis_VideoTrening_videoTreningId",
                table: "Videozapis",
                column: "videoTreningId",
                principalTable: "VideoTrening",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                table: "ClanarinaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                table: "ClanarinaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Adresa_adresaID",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Role_roleId",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_Adresa_adresaId",
                table: "Lokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Korisnik_korisnikID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaPlacanje_Narudzba_narudzbaID",
                table: "NarudzbaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_NarudzbaPlacanje_Placanje_placanjeID",
                table: "NarudzbaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PlanIshrane_planIshraneID",
                table: "planIshrane_PrehrambeniArtikal");

            migrationBuilder.DropForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PrehrambeniArtikal_prehrambeniArtikalID",
                table: "planIshrane_PrehrambeniArtikal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktNarudzba_Narudzba_narudzbaID",
                table: "ProduktNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_ProduktNarudzba_Produkt_produktID",
                table: "ProduktNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Korisnik_korisnikId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Lokacija_lokacijaId",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Termin_Rezervacija_rezervacijaId",
                table: "Termin");

            migrationBuilder.DropForeignKey(
                name: "FK_Videozapis_VideoTrening_videoTreningId",
                table: "Videozapis");

            migrationBuilder.DropColumn(
                name: "putanjaSlike",
                table: "Korisnik");

            migrationBuilder.AlterColumn<DateTime>(
                name: "datumRodjenja",
                table: "Korisnik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                table: "ClanarinaPlacanje",
                column: "clanarinaID",
                principalTable: "Clanarina",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                table: "ClanarinaPlacanje",
                column: "placanjeID",
                principalTable: "Placanje",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Adresa_adresaID",
                table: "Korisnik",
                column: "adresaID",
                principalTable: "Adresa",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Role_roleId",
                table: "Korisnik",
                column: "roleId",
                principalTable: "Role",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacija_Adresa_adresaId",
                table: "Lokacija",
                column: "adresaId",
                principalTable: "Adresa",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Korisnik_korisnikID",
                table: "Narudzba",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaPlacanje_Narudzba_narudzbaID",
                table: "NarudzbaPlacanje",
                column: "narudzbaID",
                principalTable: "Narudzba",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_NarudzbaPlacanje_Placanje_placanjeID",
                table: "NarudzbaPlacanje",
                column: "placanjeID",
                principalTable: "Placanje",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PlanIshrane_planIshraneID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "planIshraneID",
                principalTable: "PlanIshrane",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_planIshrane_PrehrambeniArtikal_PrehrambeniArtikal_prehrambeniArtikalID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "prehrambeniArtikalID",
                principalTable: "PrehrambeniArtikal",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktNarudzba_Narudzba_narudzbaID",
                table: "ProduktNarudzba",
                column: "narudzbaID",
                principalTable: "Narudzba",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktNarudzba_Produkt_produktID",
                table: "ProduktNarudzba",
                column: "produktID",
                principalTable: "Produkt",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Korisnik_korisnikId",
                table: "Rezervacija",
                column: "korisnikId",
                principalTable: "Korisnik",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Lokacija_lokacijaId",
                table: "Termin",
                column: "lokacijaId",
                principalTable: "Lokacija",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Termin_Rezervacija_rezervacijaId",
                table: "Termin",
                column: "rezervacijaId",
                principalTable: "Rezervacija",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videozapis_VideoTrening_videoTreningId",
                table: "Videozapis",
                column: "videoTreningId",
                principalTable: "VideoTrening",
                principalColumn: "id");
        }
    }
}
