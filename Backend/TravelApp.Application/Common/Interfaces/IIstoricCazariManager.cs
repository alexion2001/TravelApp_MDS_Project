using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IIstoricCazariManager
    {
       
        Task<dynamic> GetCazariByName(String username);
        Task<IstoricCazari> GetIstoricCazari(Guid IdUser);
        void Create(IstoricCazari entity);

        void CreateRange(IEnumerable<IstoricCazari> entities);
        Task<bool> SaveAsync();
    }
}
