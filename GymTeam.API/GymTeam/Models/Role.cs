using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GymTeam.Models
{
    public class Role: IdentityRole<string>
    {
     
        public RoleDefinition Rolename { get; set; }
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
