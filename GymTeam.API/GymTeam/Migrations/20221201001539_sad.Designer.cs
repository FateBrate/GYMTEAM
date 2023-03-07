﻿// <auto-generated />
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
    [Migration("20221201001539_sad")]
    partial class sad
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("GymTeam.Moduls.Lokacija", b =>
                {
                    b.HasOne("GymTeam.Moduls.Adresa", "adresa")
                        .WithMany()
                        .HasForeignKey("adresaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("adresa");
                });
#pragma warning restore 612, 618
        }
    }
}
