using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IIstoricVacanteManager
    {
        Task<IstoricVacante> GetIstoricZbor(Guid id);
        Task<dynamic> GetVacanteByUser(Guid userid);

        Task<dynamic> GetIdVacanta(Guid id);
        void Create(IstoricVacante entity);

        void CreateRange(IEnumerable<IstoricVacante> entities);
        Task<bool> SaveAsync();
    }
}
