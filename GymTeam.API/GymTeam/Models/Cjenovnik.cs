using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Cjenovnik
    {
        [Key]
        public int id { get; set; }
        public string nazivStavke { get; set; }
        public string opis { get; set; }
        
        public float cijena { get; set; }

        [ForeignKey("korisnikId")]
        public int korisnikId { get; set; } 
        public Korisnik korisnik { get; set; }


    }
}
