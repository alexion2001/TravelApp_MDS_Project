using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class CreateZboruriUsersDTO
    {
       // public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ZborId { get; set; }
        public String Status { get; set; }
    }
}
