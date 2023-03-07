using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Moduls
{
    public class Lokacija
    {
        [Key]
        public int id { get; set; }
        public string  naziv { get; set; }
        public string putanjaSlike { get; set; }
      
        [ForeignKey("adresaId")]
        public Adresa adresa { get; set; }
        public int adresaId { get; set; }
        
    }
}
