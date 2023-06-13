using System.ComponentModel.DataAnnotations;

namespace GymTeam.Models
{
    public class VideoTrening
    {
        [Key]
        public int id { get; set; }
        public string naslov { get; set; }

        public string ukupnoTrajanje { get; set; }
        public string opis { get; set; }
        
    }
}
