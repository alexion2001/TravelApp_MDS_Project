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
    public class IstoricZborManager : IIstoricZborManager
    {
        private readonly TravelDbContext _context;
        public IstoricZborManager(TravelDbContext context)
        {
            _context = context;

        }
        public async Task<IstoricZbor> GetIstoricZbor(Guid IdUser)
        {
            var zbor = await _context.IstoricZboruri.Where(u => u.IdUser.Equals(IdUser)).SingleOrDefaultAsync();
            return zbor;

        }

        public async Task<dynamic> GetZborById(Guid userid)
        {

            var result = from zboruri in _context.IstoricZboruri
                         where zboruri.IdUser == userid

                         select new
                         {

                             datap = zboruri.data_plecare,
                             datav = zboruri.data_retur,
                             op = zboruri.oras_plecare,
                             ov = zboruri.oras_sosire,
                             buget = zboruri.buget

                         };
            var final = result.AsEnumerable();
            return final;
        }

        public async Task<dynamic> GetZborByName(string Username)
        {
            var result = from u in _context.IdentityUsers
                         join i in _context.IstoricZboruri
                         on u.Id equals i.IdUser
                         where Username == u.Username
                         select new
                         {
                             datap = i.data_plecare,
                             datav = i.data_retur,
                             op = i.oras_plecare,
                             ov = i.oras_sosire,
                             buget = i.buget,
                             email = u.Email
                         };
            var final = result.AsEnumerable();
            return final;
        }
        public void Create(IstoricZbor entity)
        {
            _context.Set<IstoricZbor>().Add(entity);
        }

        public void CreateRange(IEnumerable<IstoricZbor> entities)
        {
            _context.Set<IstoricZbor>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
