using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class CreateCazariUsersDTO
    {
       // public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CazareId { get; set; }
        public String Status { get; set; }
    }
}
