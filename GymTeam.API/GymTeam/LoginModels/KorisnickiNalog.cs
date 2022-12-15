using GymTeam.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GymTeam.LoginModels
{
    public class KorisnickiNalog
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public string lozinka { get; set; }
        public string slikaKorisnika { get; set; }
        [ForeignKey("roleId")]
        public Role Uloga { get; set; }
        public int roleId { get; set; }

    }
}
