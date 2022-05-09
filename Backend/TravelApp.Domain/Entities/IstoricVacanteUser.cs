using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class IstoricVacanteUser
    {
        public IstoricVacanteUser() { }
        public IstoricVacanteUser(Guid userid, Guid vacantaid)
        {
            this.UserId = userid;
            this.Vacantaid = vacantaid;

        }
        public Guid UserId { get; set; }
        public Guid Vacantaid { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual IstoricVacante IstoricVacante { get; set; }
        
    }
}
