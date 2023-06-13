using GymTeam.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GymTeam.ViewModels
{
    public class ObavijestVM
    {
        
        public int id { get; set; }
        public string naslov { get; set; }
        public DateTime datumObjave { get; set; }
        public string tip { get; set; }
        public string sadrzaj { get; set; }
    
        public int korisnikId { get; set; }
        public string  slika { get; set; }
    }
}
