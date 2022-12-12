namespace GymTeam.ViewModels
{
    public class NarudzbaGetVM
    {
        public int id { get; set; }
        public int brojNarudzbe { get; set; }
        public DateTime datumNarudzbe { get; set; }
        public string popust { get; set; }
        public string cijena { get; set; }
        public int korisnikID { get; set; }
    }
}
