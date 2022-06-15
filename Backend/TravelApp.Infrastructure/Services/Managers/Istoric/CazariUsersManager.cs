using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;

namespace TravelApp.Infrastructure.Services.Managers.Istoric
{
    class CazariUsersManager : ICazariUsersManager
    {
        private readonly TravelDbContext _context;
        public CazariUsersManager(TravelDbContext context)
        {
            _context = context;

        }
        public async Task<CazariUsers> GetCazari(Guid id)
        {
            var cazare = await _context.CazariUsers.Where(u => u.Id.Equals(id)).SingleOrDefaultAsync();
            return cazare;

        }

        public async Task<dynamic> GetCazariByUser(Guid user)
        {

            var result = from cazari in _context.CazariUsers
                         join ist in _context.IstoriceCazari
                         on cazari.CazareId equals ist.Id
                         where cazari.UserId == user

                         select new
                         {
                             id = cazari.Id,
                             datap = ist.data_plecare,
                             datav = ist.data_venire,
                             oras = ist.oras,
                             nume = ist.numeLoc,
                             buget = ist.buget

                         };
            var final = result.AsEnumerable();
            return final;
        }

        public async Task<dynamic> GetCazariByUserStatus(Guid user, String status)
        {

            var result = from cazari in _context.CazariUsers
                         join ist in _context.IstoriceCazari
                         on cazari.CazareId equals ist.Id
                         where cazari.UserId == user && cazari.Status == status

                         select new
                         {
                             id = cazari.Id,
                             datap = ist.data_plecare,
                             datav = ist.data_venire,
                             oras = ist.oras,
                             nume = ist.numeLoc,
                             buget = ist.buget

                         };
            var final = result.AsEnumerable();
            return final;
        }
        public void Create(CazariUsers entity, String status)
        {
            _context.Set<CazariUsers>().Add(entity);
        }

        public void CreateRange(IEnumerable<CazariUsers> entities)
        {
            _context.Set<CazariUsers>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(CazariUsers entity)
        {
            _context.Set<CazariUsers>().Update(entity);
        }
        public async Task<CazariUsers> GetById(Guid id)
        {
            return await _context.Set<CazariUsers>().FindAsync(id);
        }
    }
}
