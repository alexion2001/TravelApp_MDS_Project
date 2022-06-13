using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface ICazariUserManager
    {
        Task<dynamic> GetIdCazari(Guid userid);
        Task<dynamic> GetInfoCazari(Guid userid);
    }
}
