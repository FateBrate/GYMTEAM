using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class PlanIshrane_PrehrambeniArtikal
    {
        [Key]
        public int id { get; set; }
        public int kolicina { get; set; }
        [ForeignKey("prehrambeniArtiaklID")]
        public int prehrambeniArtikalID { get; set; }
        public PrehrambeniArtikal prehrambeniArtikal { get; set; }
        [ForeignKey("planIshraneID")]
        public int planIshraneID { get; set; }
        public PlanIshrane planIshrane { get; set; }
    }
}
