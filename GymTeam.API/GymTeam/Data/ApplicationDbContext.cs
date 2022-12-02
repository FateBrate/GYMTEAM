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
        
        public DbSet<Videozapis> Videozapis { get; set; }  
        public DbSet<Clanarina> Clanarina { get; set; }   
        public DbSet<Rezervacija> Rezervacija { get; set; }   



        

        public ApplicationDbContext(
           DbContextOptions options) : base(options)
        {
        }
    }
}
