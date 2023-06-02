using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Rezervacija
    {
        [Key]
        public int id { get; set; }
        public DateTime datumRezervacije { get; set; }
        [ForeignKey("rezervacijaKorisnikId")]
        public int rezervacijaKorisnikId { get; set; } 
        public Korisnik korisnik { get; set; }  


    }
}
