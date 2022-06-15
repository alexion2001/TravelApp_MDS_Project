using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IZboruriUsersManager
    {
        Task<ZboruriUsers> GetZboruri(Guid id);
        Task<dynamic> GetZborByUser(Guid user);
        Task<dynamic> GetZboruriByUserStatus(Guid user, String status);
        void Create(ZboruriUsers entity);
        void CreateRange(IEnumerable<ZboruriUsers> entities);
        Task<bool> SaveAsync();
        void Update(ZboruriUsers entity);
        Task<ZboruriUsers> GetById(Guid id);
    }
}
