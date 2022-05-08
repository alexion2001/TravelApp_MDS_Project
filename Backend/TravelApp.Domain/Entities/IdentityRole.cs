using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public partial class IdentityRole
    {
        public IdentityRole()
        {
      
            IdentityUserRoles = new List<IdentityUserIdentityRole>();

        }
        //public IdentityRole(string name,Guid identityuserid)
        public IdentityRole(string name, Guid id)
        {
            this.Id = id;
            this.Name = name;
            // FK_IdentityRole_IdentityUser_IdentityUserId
            //this.IdentityUserRoles.Add(new IdentityUserIdentityRole(identityuserid, this.Id));


        }
        public Guid Id { get; set; }
        public string Name { get; set; }

 
        public List<IdentityUserIdentityRole> IdentityUserRoles { get; set; }
    }
}
