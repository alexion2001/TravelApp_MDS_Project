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
    class IstoricVacanteManager :IIstoricVacanteManager
    {
            private readonly TravelDbContext _context;
            public IstoricVacanteManager(TravelDbContext context)
            {
                _context = context;

            }
            public async Task<IstoricVacante> GetIstoricZbor(Guid id)
            {
                var v = await _context.IstoriceVacante.Where(u => u.VacantaId.Equals(id)).SingleOrDefaultAsync();
                return v;

            }
        public async Task<dynamic> GetVacanteByUser(Guid userid)
        {
            var ids = from asoc in _context.IstoricVacanteUsers
                      where asoc.UserId == userid
                      select new
                      {
                          vacanta = asoc.Vacantaid
                      };
            var final = ids.AsEnumerable().GroupBy(i => i.vacanta);
            var rez1 = new List<dynamic>();
            foreach (var i in final)
            {
                var j = from v in _context.IstoriceVacante
                        join zboruri in _context.IstoricZboruri
                        on v.ZborId equals zboruri.Id
                        select new
                        {
                            id = v.VacantaId,
                            datap = zboruri.data_plecare,
                            datav = zboruri.data_retur,
                            op = zboruri.oras_plecare,
                            ov = zboruri.oras_sosire,
                            buget = zboruri.buget
                        };
                rez1.Add(j);
                rez1.Where(p => p.id == i);
            }
            return rez1;
        }
        public async Task<dynamic> GetIdVacanta(Guid id)
        {
            var result = from ist in _context.IstoricVacanteUsers
                         join v in _context.IstoriceVacante
                         on ist.UserId equals id
                         select new
                         {
                             id1 = v.ZborId
                         };
            var final = result.AsEnumerable().GroupBy(i => i.id1);
            var rez1 = new List<dynamic>();
            foreach (var zb in final)
            {
                var m = await _context.IstoricZboruri.Where(u => u.Id.Equals(zb)).SingleOrDefaultAsync();
                rez1.Add(m);
            }
            return rez1;
        }
        public void Create(IstoricVacante entity)
        {
            _context.Set<IstoricVacante>().Add(entity);
        }

        public void CreateRange(IEnumerable<IstoricVacante> entities)
        {
            _context.Set<IstoricVacante>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
