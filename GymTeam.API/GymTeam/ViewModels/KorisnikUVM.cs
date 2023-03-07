namespace GymTeam.ViewModels
{
    public class KorisnikUVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string lozinka { get; set; }
        public string email { get; set; }
        public int? lokacijaId { get; set; }
        public DateTime? datumRodjenja { get; set; }
        public string brojTelefona { get; set; }
        public int roleID { get; set; }
        public string? putanjaSlike { get; set; }
    }
}
