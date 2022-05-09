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
        public Guid Cazariid { get; set; }
        public virtual IstoricZbor Zbor { get; set; }
        public virtual IstoricCazari Cazari { get; set; }
        public virtual ICollection<IstoricVacanteUser> IstoricVacanteUsers { get; set; }
    }
}
