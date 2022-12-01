using GymTeam.Moduls;
using Microsoft.EntityFrameworkCore;

namespace GymTeam.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Adresa> Adresa{ get; set; }
        public DbSet<Lokacija> Lokacija{ get; set; }

        public ApplicationDbContext(
           DbContextOptions options) : base(options)
        {
        }
    }
}
