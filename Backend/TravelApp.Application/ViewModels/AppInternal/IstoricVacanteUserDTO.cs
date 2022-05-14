using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    class IstoricVacanteUserDTO
    {
        public Guid UserId { get; set; }
        public Guid Vacantaid { get; set; }

        public IstoricVacanteUserDTO(IstoricVacanteUser ist)
        {
            this.UserId = ist.UserId;
            this.Vacantaid = ist.Vacantaid;
        }
    }
}
