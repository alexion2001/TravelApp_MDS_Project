using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class CreateRecenziiUserDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdMesaj { get; set; }
        public DateTime DataMesaj { get; set; }

    }
}
