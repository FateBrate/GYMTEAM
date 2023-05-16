using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace GymTeam.Moduls
{
    public class Adresa
    {
        [Key]
        public int id { get; set; }
        public string nazivGrada { get; set; }
        public string NazivUlice { get; set; }
        public int postanskiBroj { get; set; }
        public string toString()
        {
            return nazivGrada + " " + NazivUlice + " " + postanskiBroj;
        }

    }
}
