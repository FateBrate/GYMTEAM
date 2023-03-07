using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Rezervacija
    {
        [Key]
        public int id { get; set; }
        public DateTime datumRezervacije { get; set; }
        [ForeignKey("korisnikId")]
        public int korisnikId { get; set; } 
        public Korisnik korisnik { get; set; }  


    }
}
