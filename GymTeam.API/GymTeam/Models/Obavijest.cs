using System.ComponentModel.DataAnnotations;

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
    }
}
