using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class RecenziiUserDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdMesaj { get; set; }
        public DateTime DataMesaj { get; set; }

        public RecenziiUserDTO(RecenziiUsers r)
        {
            this.UserId = r.UserId;
            this.IdMesaj = r.IdMesaj;
            this.DataMesaj = r.DataMesaj;
        }
    }
}
