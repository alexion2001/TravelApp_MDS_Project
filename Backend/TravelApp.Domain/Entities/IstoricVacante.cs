using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
   public class IstoricVacante
    {
        public Guid VacantaId { get; set; }
        public Guid ZborId { get; set; }
        public virtual IstoricZbor IstoricZbor { get; set; }
        public Guid Cazareid { get; set; }
        public virtual IstoricCazari IstoricCazari { get; set; }
        public virtual ICollection<IstoricVacanteUser> IstoricVacanteUsers { get; set; }
    }
}
