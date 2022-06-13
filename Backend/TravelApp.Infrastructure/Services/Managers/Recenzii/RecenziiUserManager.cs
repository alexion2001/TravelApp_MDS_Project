using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;

namespace TravelApp.Infrastructure.Services.Managers.Recenzii
{
    public class RecenziiUserManager : IRecenziiUserManager
    {
        private readonly TravelDbContext _context;
        public RecenziiUserManager(TravelDbContext context)
        {
            _context = context;

        }
        public async Task<dynamic> GetRecenzii(Guid userid)
        {
            var result = from rec in _context.RecenziiUsersC
                         join r in _context.RecenziiC
                         on rec.IdMesaj equals r.Id
                         where rec.UserId == userid
                         select new
                         {
                             id = rec.IdMesaj,
                             oras = r.Oras,
                             mesaj = r.Mesaj,
                             data = rec.DataMesaj
                         };
            var final = result.AsEnumerable();
            return final;
        }
       public async Task<dynamic> GetNumeUser(Guid userid)
        {
            var result = from user in _context.IdentityUsers
                         where user.Id == userid
                         select new
                         {
                             nume = user.Username
                         };
            var final = result.AsEnumerable();
            return final;

        }
        public void Create(RecenziiUsers entity)
        {
            _context.Set<RecenziiUsers>().Add(entity);
        }

        public void CreateRange(IEnumerable<RecenziiUsers> entities)
        {
            _context.Set<RecenziiUsers>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
       
        public async Task<RecenziiUsers> GetById(Guid id)
        {
            return await _context.Set<RecenziiUsers>().FindAsync(id);
        }
        public void Delete(RecenziiUsers entity)
        {
            _context.Set<RecenziiUsers>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<RecenziiUsers> entities)
        {
            _context.Set<RecenziiUsers>().RemoveRange(entities);
        }
    }
}
