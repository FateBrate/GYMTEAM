using System.ComponentModel.DataAnnotations;

namespace GymTeam.Models
{
    public class Clanarina
    {
        [Key]
        public int id { get; set; }
        public string iznos { get; set; }
        public DateTime datumUplate { get; set; }
        public DateTime datumVazenja { get; set; } 
        

    }
}
