using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class _151216sati : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cjenovnik_Korisnik_korisnikId",
                table: "Cjenovnik");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                table: "ClanarinaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                table: "ClanarinaPlacanje");

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
                name: "FK_Obavijest_Korisnik_korisnikId",
                table: "Obavijest");

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

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slikaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.id);
                    table.ForeignKey(
                        name: "FK_KorisnickiNalog_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_korisnickiNalogId",
                        column: x => x.korisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_korisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "korisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_roleId",
                table: "KorisnickiNalog",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cjenovnik_Korisnik_korisnikId",
                table: "Cjenovnik",
                column: "korisnikId",
                principalTable: "Korisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

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
                name: "FK_Obavijest_Korisnik_korisnikId",
                table: "Obavijest",
                column: "korisnikId",
                principalTable: "Korisnik",
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
                name: "FK_Cjenovnik_Korisnik_korisnikId",
                table: "Cjenovnik");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                table: "ClanarinaPlacanje");

            migrationBuilder.DropForeignKey(
                name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                table: "ClanarinaPlacanje");

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
                name: "FK_Obavijest_Korisnik_korisnikId",
                table: "Obavijest");

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

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.AddForeignKey(
                name: "FK_Cjenovnik_Korisnik_korisnikId",
                table: "Cjenovnik",
                column: "korisnikId",
                principalTable: "Korisnik",
                principalColumn: "id");

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
                name: "FK_Obavijest_Korisnik_korisnikId",
                table: "Obavijest",
                column: "korisnikId",
                principalTable: "Korisnik",
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
