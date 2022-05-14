using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Entities
{
    public class IstoricCazari
    {
        public Guid Id { get; set; }
        public DateTime data_venire { get; set; }
        public DateTime data_plecare { get; set; }
        public string oras { get; set; }
        public string numeLoc { get; set; }
        public int buget { get; set; }
        public virtual ICollection<CazariUsers> CazariUsers { get; set; }
    }
}
