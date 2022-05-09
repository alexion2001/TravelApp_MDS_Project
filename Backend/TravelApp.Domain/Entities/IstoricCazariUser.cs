using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class IstoricCazariUser
    {
        public IstoricCazariUser() { }
        public IstoricCazariUser(Guid userid, Guid cazareid)
        {
            this.UserId = userid;
            this.Cazareid = cazareid;

        }
        public Guid UserId { get; set; }
        public Guid Cazareid { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
        public virtual IstoricCazari IstoricCazari { get; set; }
        

    }
}
