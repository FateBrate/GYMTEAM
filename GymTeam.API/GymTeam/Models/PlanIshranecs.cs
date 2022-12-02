using System.ComponentModel.DataAnnotations;

namespace GymTeam.Models
{
    public class PlanIshranecs
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public int ukupanBrojKalorija { get; set; }
    }
}
