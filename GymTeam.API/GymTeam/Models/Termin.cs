using GymTeam.Moduls;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Termin
    {
        [Key]
        public int id { get; set; }
        public DateTime datumOdrzavanja { get; set; }
        public string trajanje { get; set; }   
        [ForeignKey("lokacijaId")]
         public int lokacijaId { get; set; }    
        public Lokacija lokacija { get; set; }
        [ForeignKey("rezervacijaId")]
        public Rezervacija rezervacija { get; set; }
        public int rezervacijaId { get; set; }  



    }
}
