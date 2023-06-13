using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Moduls
{
    public class Lokacija
    {
        [Key]
        public int id { get; set; }
        public string  naziv { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int adresaId { get; set; }
        public byte[]? slika { get; set; }
        [ForeignKey("adresaId")]
        public Adresa adresa { get; set; }
        
    }
}
