using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface ICazariUsersManager
    {
        Task<CazariUsers> GetCazari(Guid id);
        Task<dynamic> GetCazariByUser(Guid user);
        Task<dynamic> GetCazariByUserStatus(Guid user, String status);

        void Create(CazariUsers entity, String status);

        void CreateRange(IEnumerable<CazariUsers> entities);
        Task<bool> SaveAsync();
        void Update(CazariUsers entity);
        Task<CazariUsers> GetById(Guid id);
    }
}
