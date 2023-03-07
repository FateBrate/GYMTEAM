using System.ComponentModel.DataAnnotations;

namespace GymTeam.Models
{
    public class Placanje
    {
        [Key]
        public int id { get; set; }
        public string tip { get; set; }
        public string iznos { get; set; }
    }
}
