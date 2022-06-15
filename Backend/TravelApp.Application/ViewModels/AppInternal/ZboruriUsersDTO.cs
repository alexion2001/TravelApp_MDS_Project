using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class ZboruriUsersDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ZborId { get; set; }
        public String Status { get; set; }
        public ZboruriUsersDTO(ZboruriUsers c)
        {
            this.UserId = c.UserId;
            this.ZborId = c.ZborId;
            this.Status = c.Status;

        }
    }
}
