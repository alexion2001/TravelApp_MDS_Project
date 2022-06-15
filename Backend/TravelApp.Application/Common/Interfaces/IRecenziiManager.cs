using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IRecenziiManager
    {
        void Create(Recenzii entity);
        Task<List<Recenzii>> GetAllRec();
        void CreateRange(IEnumerable<Recenzii> entities);
        Task<bool> SaveAsync();
        void Update(Recenzii entity);
        Task<Recenzii> GetById(Guid id);
        void Delete(Recenzii entity);
        void DeleteRange(IEnumerable<Recenzii> entities);
    }


}
