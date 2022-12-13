using System.ComponentModel.DataAnnotations;

namespace GymTeam.Models
{
    public class PrehrambeniArtikal
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public int brojKalorija { get; set; }
        public string kategorija { get; set; }

    }
}
