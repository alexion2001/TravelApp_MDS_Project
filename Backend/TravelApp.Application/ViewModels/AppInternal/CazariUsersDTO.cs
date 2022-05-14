using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class CazariUsersDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CazareId { get; set; }
        public String Status { get; set; }
        public CazariUsersDTO(CazariUsers c)
        {
            this.UserId = c.UserId;
            this.CazareId = c.CazareId;
            this.Status = c.Status;

        }
    }
}
