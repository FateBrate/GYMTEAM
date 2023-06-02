using GymTeam.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.LoginModels
{
    public class AutentifikacijaToken
    {
        [Key]
        public int id { get; set; }
        public string vrijednost { get; set; }

        [ForeignKey("autentifikacijaTokenKorisnikId")]
        public int autentifikacijaTokenKorisnikId { get; set; }
        public Korisnik korisnik { get; set; }
        public DateTime vrijemeEvidentiranja { get; set; }
        public string ipAdresa { get; set; }
        
    }
}
