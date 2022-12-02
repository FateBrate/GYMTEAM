using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class ProduktNarudzba
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("narudzbaID")]
        public int narudzbaID { get; set; }
        public Narudzba narudzba { get; set; }

        [ForeignKey("produktID")]
        public int produktID { get; set; }
        public Produkt produkt { get; set; }
        public int kolicina { get; set; }

    }
}
