using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GymTeam.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public RoleDefinition Rolename { get; set; }
        public void setrole()
        {
            if (this.id == 1)
                this.Rolename = RoleDefinition.Admin;
            else if (this.id == 2)
                this.Rolename = RoleDefinition.Employee;
            else this.Rolename = RoleDefinition.GuestUser;
        }
        public override string ToString()
        {
            if (this.Rolename==RoleDefinition.Admin)
                return "Admin";
            else if (this.Rolename == RoleDefinition.Employee)
                return "Employee";
            else return "GuestUser";
        }
     

    }
}
