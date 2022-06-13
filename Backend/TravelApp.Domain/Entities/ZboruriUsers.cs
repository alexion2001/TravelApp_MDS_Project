using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class ZboruriUsers
    {
        public ZboruriUsers() { }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ZborId { get; set; }
        public String Status { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
        public virtual IstoricZbor IstoricZbor { get; set; }
    }
}
