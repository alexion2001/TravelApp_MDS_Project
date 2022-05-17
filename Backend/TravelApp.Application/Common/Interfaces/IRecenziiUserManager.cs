using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IRecenziiUserManager
    {
        Task<dynamic> GetRecenzii(Guid userid);
        Task<dynamic> GetNumeUser(Guid userid);
        void Create(RecenziiUsers entity);

        void CreateRange(IEnumerable<RecenziiUsers> entities);
        Task<bool> SaveAsync();

        Task<RecenziiUsers> GetById(Guid id);
        void Delete(RecenziiUsers entity);
        void DeleteRange(IEnumerable<RecenziiUsers> entities);
    }
}
