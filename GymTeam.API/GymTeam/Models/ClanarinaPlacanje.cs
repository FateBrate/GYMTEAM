using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class ClanarinaPlacanje
    {
        [ForeignKey("clanarinaID")]
        public int clanarinaID { get; set; }
        public Clanarina clanarina { get; set; }
        [ForeignKey("placanjeID")]
        public int placanjeID { get; set; }
        public Placanje placanje { get; set; }
    }
}
