using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class IstoricVacantaDTO
    {

        public Guid ZborId { get; set; }
        public Guid Cazariid { get; set; }
        public IstoricVacantaDTO(IstoricVacante c)
        {
            this.ZborId = c.ZborId;
            this.Cazariid = c.Cazariid;
           
        }
    }
}
