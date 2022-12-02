using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class NarudzbaPlacanje
    {
        [ForeignKey("narudzbaID")]
        public int narudzbaID { get; set; }
        public Narudzba narudzba { get; set; }
        [ForeignKey("placanjeID")]
        public int placanjeID { get; set; }
        public Placanje placanje { get; set; }
        [Key]
        public int id { get; set; }
    }
}
