﻿// <auto-generated />
using System;
using GymTeam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymTeam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221203013923_nesto")]
    partial class nesto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymTeam.Models.Cjenovnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("sadržaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cjenovnik");
                });

            modelBuilder.Entity("GymTeam.Models.Clanarina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumUplate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("iznos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("GymTeam.Models.ClanarinaPlacanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("clanarinaID")
                        .HasColumnType("int");

                    b.Property<int>("placanjeID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clanarinaID");

                    b.HasIndex("placanjeID");

                    b.ToTable("ClanarinaPlacanje");
                });

            modelBuilder.Entity("GymTeam.Models.Korisnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("adresaID")
                        .HasColumnType("int");

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("adresaID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.Narudzba", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("brojNarudzbe")
                        .HasColumnType("int");

                    b.Property<string>("cijena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnikID")
                        .HasColumnType("int");

                    b.Property<string>("popust")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("korisnikID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("GymTeam.Models.NarudzbaPlacanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("narudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("placanjeID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("narudzbaID");

                    b.HasIndex("placanjeID");

                    b.ToTable("NarudzbaPlacanje");
                });

            modelBuilder.Entity("GymTeam.Models.Obavijest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("GymTeam.Models.Placanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("iznos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Placanje");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ukupanBrojKalorija")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PlanIshrane");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane_PrehrambeniArtikal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("planIshraneID")
                        .HasColumnType("int");

                    b.Property<int>("prehrambeniArtikalID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("planIshraneID");

                    b.HasIndex("prehrambeniArtikalID");

                    b.ToTable("planIshrane_PrehrambeniArtikal");
                });

            modelBuilder.Entity("GymTeam.Models.PrehrambeniArtikal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("brojKalorija")
                        .HasColumnType("int");

                    b.Property<string>("kategorija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PrehrambeniArtikal");
                });

            modelBuilder.Entity("GymTeam.Models.PrivatniTrener", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("privatniTrenerID")
                        .HasColumnType("int");

                    b.Property<int>("privatniTrenerid")
                        .HasColumnType("int");

                    b.Property<byte[]>("slika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.HasIndex("privatniTrenerid");

                    b.ToTable("PrivatniTrener");
                });

            modelBuilder.Entity("GymTeam.Models.Produkt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cijena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kategorija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("masa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sifraProdukta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zemljaPorijekla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("GymTeam.Models.ProduktNarudzba", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<int>("narudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("produktID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("narudzbaID");

                    b.HasIndex("produktID");

                    b.ToTable("ProduktNarudzba");
                });

            modelBuilder.Entity("GymTeam.Models.Rezervacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("GymTeam.Models.Termin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("lokacijaId")
                        .HasColumnType("int");

                    b.Property<int>("rezervacijaId")
                        .HasColumnType("int");

                    b.Property<string>("trajanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("lokacijaId");

                    b.HasIndex("rezervacijaId");

                    b.ToTable("Termin");
                });

            modelBuilder.Entity("GymTeam.Models.VideoTrening", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ukupnoTrajanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("VideoTrening");
                });

            modelBuilder.Entity("GymTeam.Models.Videozapis", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trajanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("videoTreningId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("videoTreningId");

                    b.ToTable("Videozapis");
                });

            modelBuilder.Entity("GymTeam.Moduls.Adresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("NazivUlice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazivGrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postanskiBroj")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Adresa");
                });

            modelBuilder.Entity("GymTeam.Moduls.Lokacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("adresaId")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("adresaId");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("GymTeam.Models.ClanarinaPlacanje", b =>
                {
                    b.HasOne("GymTeam.Models.Clanarina", "clanarina")
                        .WithMany()
                        .HasForeignKey("clanarinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Placanje", "placanje")
                        .WithMany()
                        .HasForeignKey("placanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clanarina");

                    b.Navigation("placanje");
                });

            modelBuilder.Entity("GymTeam.Models.Korisnik", b =>
                {
                    b.HasOne("GymTeam.Moduls.Adresa", "adresa")
                        .WithMany()
                        .HasForeignKey("adresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adresa");
                });

            modelBuilder.Entity("GymTeam.Models.Narudzba", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.NarudzbaPlacanje", b =>
                {
                    b.HasOne("GymTeam.Models.Narudzba", "narudzba")
                        .WithMany()
                        .HasForeignKey("narudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Placanje", "placanje")
                        .WithMany()
                        .HasForeignKey("placanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("narudzba");

                    b.Navigation("placanje");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane_PrehrambeniArtikal", b =>
                {
                    b.HasOne("GymTeam.Models.PlanIshrane", "planIshrane")
                        .WithMany()
                        .HasForeignKey("planIshraneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.PrehrambeniArtikal", "prehrambeniArtikal")
                        .WithMany()
                        .HasForeignKey("prehrambeniArtikalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("planIshrane");

                    b.Navigation("prehrambeniArtikal");
                });

            modelBuilder.Entity("GymTeam.Models.PrivatniTrener", b =>
                {
                    b.HasOne("GymTeam.Models.PrivatniTrener", "privatniTrener")
                        .WithMany()
                        .HasForeignKey("privatniTrenerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("privatniTrener");
                });

            modelBuilder.Entity("GymTeam.Models.ProduktNarudzba", b =>
                {
                    b.HasOne("GymTeam.Models.Narudzba", "narudzba")
                        .WithMany()
                        .HasForeignKey("narudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Produkt", "produkt")
                        .WithMany()
                        .HasForeignKey("produktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("narudzba");

                    b.Navigation("produkt");
                });

            modelBuilder.Entity("GymTeam.Models.Rezervacija", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.Termin", b =>
                {
                    b.HasOne("GymTeam.Moduls.Lokacija", "lokacija")
                        .WithMany()
                        .HasForeignKey("lokacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Rezervacija", "rezervacija")
                        .WithMany()
                        .HasForeignKey("rezervacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lokacija");

                    b.Navigation("rezervacija");
                });

            modelBuilder.Entity("GymTeam.Models.Videozapis", b =>
                {
                    b.HasOne("GymTeam.Models.VideoTrening", null)
                        .WithMany("videozapisi")
                        .HasForeignKey("videoTreningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymTeam.Moduls.Lokacija", b =>
                {
                    b.HasOne("GymTeam.Moduls.Adresa", "adresa")
                        .WithMany()
                        .HasForeignKey("adresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adresa");
                });

            modelBuilder.Entity("GymTeam.Models.VideoTrening", b =>
                {
                    b.Navigation("videozapisi");
                });
#pragma warning restore 612, 618
        }
    }
}
