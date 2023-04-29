using GymTeam.Moduls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GymTeam.Models
{
    public class Korisnik
    {
        [Key]
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string lozinka { get; set;}
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public DateTime? datumRodjenja { get; set; }
        [ForeignKey("lokacijaId")]
        public int? lokacijaId{ get; set; }
        public Lokacija? lokacija { get; set; }
        [ForeignKey("roleId")]
        public int roleId { get; set; }
        public Role role { get; set; }
        public byte[]? slika { get; set; }
        
   
    }
}
