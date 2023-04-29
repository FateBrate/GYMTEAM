using GymTeam.LoginModels;
using GymTeam.Models;
using GymTeam.Moduls;
using Microsoft.EntityFrameworkCore;

namespace GymTeam.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Adresa> Adresa{ get; set; }
        public DbSet<Lokacija> Lokacija{ get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }  
        public DbSet<Cjenovnik> Cjenovnik { get; set; }  
        public DbSet<VideoTrening>VideoTrening { get; set; }  
        
        public DbSet<Clanarina> Clanarina { get; set; }   
        public DbSet<Rezervacija> Rezervacija { get; set; }   
        public DbSet<ClanarinaPlacanje> ClanarinaPlacanje { get; set; }   
        public DbSet<Narudzba> Narudzba { get; set; }   
        public DbSet<NarudzbaPlacanje> NarudzbaPlacanje { get; set; }   
        public DbSet<Obavijest> Obavijest { get; set; }
        public DbSet<Placanje> Placanje { get; set; }
        public DbSet<PlanIshrane> PlanIshrane { get; set; }
        public DbSet<PlanIshrane_PrehrambeniArtikal> planIshrane_PrehrambeniArtikal { get; set; }
        public DbSet<PrivatniTrener> PrivatniTrener { get; set; }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<ProduktNarudzba> ProduktNarudzba { get; set; }
        public DbSet<Termin> Termin { get; set; }
        public DbSet<PrehrambeniArtikal> PrehrambeniArtikal { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }  
   
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }








        public ApplicationDbContext(
           DbContextOptions options) : base(options)
        {
        }
    }
}
