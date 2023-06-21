namespace GymTeam.ViewModels
{
    public class LokacijaGetVM
    {
        public int id { get; set; } 
        public string naziv { get; set; }
        public string slika { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int adresaId { get; set; }
    }
}
