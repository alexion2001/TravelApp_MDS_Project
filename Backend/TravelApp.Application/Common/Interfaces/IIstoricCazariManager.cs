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
       
        Task<IstoricCazari> GetIstoricCazari(Guid id);
        Task<dynamic> GetCazariByOras(String oras);
        void Create(IstoricCazari entity);

        void CreateRange(IEnumerable<IstoricCazari> entities);
        Task<bool> SaveAsync();
        void Update(IstoricCazari entity);
        Task<IstoricCazari> GetById(Guid id);
        
    }
}
