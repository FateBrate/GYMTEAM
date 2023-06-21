using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Obavijest
    {
        [Key]
        public int id { get; set; }
        public string naslov { get; set; }
        public DateTime datumObjave { get; set; }
        public string tip { get; set; }
        public string sadrzaj { get; set; }
        [ForeignKey("korisnikId")]
        public int korisnikId { get; set; }
        public Korisnik korisnik { get; set; }

        public byte[]? slika { get; set; }

    }
}
