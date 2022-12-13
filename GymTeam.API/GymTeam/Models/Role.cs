using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public RoleDefinition Rolename { get; set; }


    }
}
