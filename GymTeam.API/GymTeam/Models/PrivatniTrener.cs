using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace GymTeam.Models
{
    public class PrivatniTrener
    {
        [Key]
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime  { get; set; }
        public byte[] slika  { get; set; }
      
        public string email { get; set; }
        public string brojTelefona { get; set; }
        public string adresa { get; set; }

    }
}
