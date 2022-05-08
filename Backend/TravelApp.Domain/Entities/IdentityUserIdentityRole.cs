using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class IdentityUserIdentityRole
    {
        public IdentityUserIdentityRole() { }
        public IdentityUserIdentityRole(Guid userid, Guid roleid)
        {
            this.UserId = userid;
            this.RoleId = roleid;

        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }

    }
}
