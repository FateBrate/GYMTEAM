using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Videozapis
    {
        [Key]
        public int id { get; set; }
        public string trajanje { get; set; }
        public string opis{ get; set; }

        [ForeignKey("videoTreningId")]
        public int videoTreningId { get; set; }

    }
}
