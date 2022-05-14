using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IIstoricZborManager
    {
        Task<IstoricZbor> GetIstoricZbor(Guid IdUser);
        Task<dynamic> GetZborById(Guid userid);
        
        Task<dynamic> GetZborByName(string Username);
        void Create(IstoricZbor entity);

        void CreateRange(IEnumerable<IstoricZbor> entities);
        Task<bool> SaveAsync();
    }
}
