using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Narudzba
    {
        [Key]
        public int id { get; set; }
        public int brojNarudzbe { get; set; }
        public DateTime datumNarudzbe { get; set; }
        public string popust { get; set; }
        public string cijena { get; set; }
        [ForeignKey("korisnikID")]
        public int korisnikID { get; set; }
        public Korisnik korisnik { get; set; }
    }
}
