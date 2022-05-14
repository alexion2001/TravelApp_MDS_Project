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
    public class ZboruriUsersManager : IZboruriUsersManager
    {
        private readonly TravelDbContext _context;
        public ZboruriUsersManager(TravelDbContext context)
        {
            _context = context;

        }

        public async Task<ZboruriUsers> GetZboruri(Guid id)
        {
            var zbor = await _context.ZboruriUsers.Where(u => u.Id.Equals(id)).SingleOrDefaultAsync();
            return zbor;

        }

        public async Task<dynamic> GetZborByUser(Guid user)
        {

            var result = from zbor in _context.ZboruriUsers
                         join ist in _context.IstoricZboruri
                         on zbor.ZborId equals ist.Id
                         where zbor.UserId == user

                         select new
                         {
                             id = zbor.Id,
                             datap = ist.data_plecare,
                             datav = ist.data_retur,
                             orasp = ist.oras_plecare,
                             orasv = ist.oras_sosire,
                             buget = ist.buget

                         };
            var final = result.AsEnumerable();
            return final;
        }

        public async Task<dynamic> GetZboruriByUserStatus(Guid user, String status)
        {

            var result = from zbor in _context.ZboruriUsers
                         join ist in _context.IstoricZboruri
                         on zbor.ZborId equals ist.Id
                         where zbor.UserId == user && zbor.Status == status

                         select new
                         {
                             id = zbor.Id,
                             datap = ist.data_plecare,
                             datav = ist.data_retur,
                             orasp = ist.oras_plecare,
                             orasv = ist.oras_sosire,
                             buget = ist.buget

                         };
            var final = result.AsEnumerable();
            return final;
        }
        public void Create(ZboruriUsers entity)
        {
            _context.Set<ZboruriUsers>().Add(entity);
        }

        public void CreateRange(IEnumerable<ZboruriUsers> entities)
        {
            _context.Set<ZboruriUsers>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(ZboruriUsers entity)
        {
            _context.Set<ZboruriUsers>().Update(entity);
        }
        public async Task<ZboruriUsers> GetById(Guid id)
        {
            return await _context.Set<ZboruriUsers>().FindAsync(id);
        }
    }
}
