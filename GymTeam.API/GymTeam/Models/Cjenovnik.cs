using System.ComponentModel.DataAnnotations;

namespace GymTeam.Models
{
    public class Cjenovnik
    {
        [Key]
        public int id { get; set; }
        public string sadržaj { get; set; }

        public DateTime datumObjave { get; set; }




    }
}
