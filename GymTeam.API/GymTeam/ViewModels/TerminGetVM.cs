namespace GymTeam.ViewModels
{
    public class TerminGetVM
    {
        public int id { get; set; } 
        public DateTime datumOdrzavanja { get; set; }
        public string trajanje { get; set; }
        public int lokacijaId { get; set; }
        public int rezervacijaId { get; set; }
    }
}
