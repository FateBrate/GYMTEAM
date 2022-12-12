namespace GymTeam.ViewModels
{
    public class PrivatniTrenerGetVM
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public byte[] slika { get; set; }

        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string adresa { get; set; }
    }
}
