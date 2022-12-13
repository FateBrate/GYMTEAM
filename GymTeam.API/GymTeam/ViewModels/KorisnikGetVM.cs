using GymTeam.Models;

namespace GymTeam.ViewModels
{
    public class KorisnikGetVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string lozinka { get; set; }
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public int adresaId { get; set; }
        public int roleId { get;set; }
        public string role { get; set; }  
    }
}
