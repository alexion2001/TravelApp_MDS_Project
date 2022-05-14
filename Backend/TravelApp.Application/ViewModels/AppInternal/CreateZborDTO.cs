using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class CreateZborDTO
    {
        private IstoricZbor istoricZbor;

     

        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public DateTime data_plecare { get; set; }
        public DateTime data_retur { get; set; }
        public string oras_plecare { get; set; }
        public string oras_sosire { get; set; }
        public int buget { get; set; }
    }
}
