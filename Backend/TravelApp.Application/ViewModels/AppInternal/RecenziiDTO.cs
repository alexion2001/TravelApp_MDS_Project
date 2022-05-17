using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class RecenziiDTO
    {
        public Guid Id { get; set; }
        public string Oras { get; set; }
        public string Mesaj { get; set; }

        public RecenziiDTO(Recenzii c)
        {
            this.Id = c.Id;
            this.Oras = c.Oras;
            this.Mesaj = c.Mesaj;
        }
    }
}
