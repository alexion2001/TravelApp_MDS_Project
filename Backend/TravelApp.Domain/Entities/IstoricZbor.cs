using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public  class IstoricZbor
    {
        public Guid Id { get; set; }
        public DateTime data_plecare { get; set; }
        public DateTime data_retur { get; set; }
        public string oras_plecare { get; set; }
        public string oras_sosire { get; set; }
        public int buget { get; set; }
        public virtual ICollection<ZboruriUsers> ZboruriUsers { get; set; }

    }
}
