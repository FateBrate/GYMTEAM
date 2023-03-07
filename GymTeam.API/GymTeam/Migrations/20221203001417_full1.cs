using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class full1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cjenovnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sadržaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumObjave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cjenovnik", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iznos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumVazenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Adresa_adresaID",
                        column: x => x.adresaID,
                        principalTable: "Adresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iznos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlanIshrane",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ukupanBrojKalorija = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIshrane", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrehrambeniArtikal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojKalorija = table.Column<int>(type: "int", nullable: false),
                    kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrehrambeniArtikal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrivatniTrener",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slika = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    privatniTrenerID = table.Column<int>(type: "int", nullable: false),
                    privatniTrenerid = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivatniTrener", x => x.id);
                    table.ForeignKey(
                        name: "FK_PrivatniTrener_PrivatniTrener_privatniTrenerid",
                        column: x => x.privatniTrenerid,
                        principalTable: "PrivatniTrener",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sifraProdukta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zemljaPorijekla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    masa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VideoTrening",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ukupnoTrajanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTrening", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojNarudzbe = table.Column<int>(type: "int", nullable: false),
                    datumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    popust = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClanarinaPlacanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clanarinaID = table.Column<int>(type: "int", nullable: false),
                    placanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanarinaPlacanje", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                        column: x => x.clanarinaID,
                        principalTable: "Clanarina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                        column: x => x.placanjeID,
                        principalTable: "Placanje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "planIshrane_PrehrambeniArtikal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prehrambeniArtikalID = table.Column<int>(type: "int", nullable: false),
                    planIshraneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planIshrane_PrehrambeniArtikal", x => x.id);
                    table.ForeignKey(
                        name: "FK_planIshrane_PrehrambeniArtikal_PlanIshrane_planIshraneID",
                        column: x => x.planIshraneID,
                        principalTable: "PlanIshrane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_planIshrane_PrehrambeniArtikal_PrehrambeniArtikal_prehrambeniArtikalID",
                        column: x => x.prehrambeniArtikalID,
                        principalTable: "PrehrambeniArtikal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Videozapis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trajanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaPlacanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    narudzbaID = table.Column<int>(type: "int", nullable: false),
                    placanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaPlacanje", x => x.id);
                    table.ForeignKey(
                        name: "FK_NarudzbaPlacanje_Narudzba_narudzbaID",
                        column: x => x.narudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NarudzbaPlacanje_Placanje_placanjeID",
                        column: x => x.placanjeID,
                        principalTable: "Placanje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProduktNarudzba",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    narudzbaID = table.Column<int>(type: "int", nullable: false),
                    produktID = table.Column<int>(type: "int", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktNarudzba", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProduktNarudzba_Narudzba_narudzbaID",
                        column: x => x.narudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProduktNarudzba_Produkt_produktID",
                        column: x => x.produktID,
                        principalTable: "Produkt",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumOdrzavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trajanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lokacijaId = table.Column<int>(type: "int", nullable: false),
                    rezervacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.id);
                    table.ForeignKey(
                        name: "FK_Termin_Lokacija_lokacijaId",
                        column: x => x.lokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Termin_Rezervacija_rezervacijaId",
                        column: x => x.rezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanarinaPlacanje_clanarinaID",
                table: "ClanarinaPlacanje",
                column: "clanarinaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanarinaPlacanje_placanjeID",
                table: "ClanarinaPlacanje",
                column: "placanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_adresaID",
                table: "Korisnik",
                column: "adresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_korisnikID",
                table: "Narudzba",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaPlacanje_narudzbaID",
                table: "NarudzbaPlacanje",
                column: "narudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaPlacanje_placanjeID",
                table: "NarudzbaPlacanje",
                column: "placanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_planIshrane_PrehrambeniArtikal_planIshraneID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "planIshraneID");

            migrationBuilder.CreateIndex(
                name: "IX_planIshrane_PrehrambeniArtikal_prehrambeniArtikalID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "prehrambeniArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_PrivatniTrener_privatniTrenerid",
                table: "PrivatniTrener",
                column: "privatniTrenerid");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktNarudzba_narudzbaID",
                table: "ProduktNarudzba",
                column: "narudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktNarudzba_produktID",
                table: "ProduktNarudzba",
                column: "produktID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_korisnikId",
                table: "Rezervacija",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_lokacijaId",
                table: "Termin",
                column: "lokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_rezervacijaId",
                table: "Termin",
                column: "rezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Videozapis_videoTreningId",
                table: "Videozapis",
                column: "videoTreningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cjenovnik");

            migrationBuilder.DropTable(
                name: "ClanarinaPlacanje");

            migrationBuilder.DropTable(
                name: "NarudzbaPlacanje");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "planIshrane_PrehrambeniArtikal");

            migrationBuilder.DropTable(
                name: "PrivatniTrener");

            migrationBuilder.DropTable(
                name: "ProduktNarudzba");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "Videozapis");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "Placanje");

            migrationBuilder.DropTable(
                name: "PlanIshrane");

            migrationBuilder.DropTable(
                name: "PrehrambeniArtikal");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "VideoTrening");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
