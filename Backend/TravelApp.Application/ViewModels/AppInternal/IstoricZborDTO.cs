using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class IstoricZborDTO
    {

        public DateTime data_plecare { get; set; }
        public DateTime data_retur { get; set; }
        public string oras_plecare { get; set; }
        public string oras_sosire { get; set; }
        public int buget { get; set; }
        public string status { get; set; }

        public IstoricZborDTO(IstoricZbor c)
        {
            this.data_plecare = c.data_plecare;
            this.data_retur = c.data_retur;
            this.oras_plecare = c.oras_plecare;
            this.oras_sosire = c.oras_sosire;
            this.buget = c.buget;

        }
    }
}
