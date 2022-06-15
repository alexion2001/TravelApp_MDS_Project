using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class RecenziiUsers
    {
        public RecenziiUsers() { }
   
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdMesaj { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual Recenzii Recenzii { get; set; }
        public DateTime DataMesaj { get; set; }

    }
}
