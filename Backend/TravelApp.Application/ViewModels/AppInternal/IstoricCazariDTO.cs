using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class IstoricCazariDTO
    {
        public DateTime data_venire { get; set; }
        public DateTime data_plecare { get; set; }
        public string oras { get; set; }
        public string numeLoc { get; set; }
        public int buget { get; set; }
        public IstoricCazariDTO(IstoricCazari c)
        {
            this.data_venire = c.data_venire;
            this.data_plecare = c.data_plecare;
            this.oras = c.oras;
            this.buget = c.buget;
           this.numeLoc = c.numeLoc;
        }

    }
}
