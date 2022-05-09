using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class Recenzii
    {
        public Guid Id { get; set; }
        public string Oras { get; set; }
        public string Mesaj { get; set; }
        public virtual ICollection<RecenziiUsers> RecenziiUsers { get; set; }
    }
}
