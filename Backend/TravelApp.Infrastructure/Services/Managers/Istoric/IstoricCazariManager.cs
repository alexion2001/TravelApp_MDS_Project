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
    internal class IstoricCazariManager : IIstoricCazariManager
    {
        private readonly TravelDbContext _context;
        public IstoricCazariManager( TravelDbContext context)
        {
            _context = context;

        }
        public async Task<IstoricCazari> GetIstoricCazari(Guid id)
        {
            var cazare = await _context.IstoriceCazari.Where(u => u.Id.Equals(id)).SingleOrDefaultAsync();
            return cazare;

        }
        public async Task<dynamic> GetCazariByOras(String oras)
        {

            var result = from cazari in _context.IstoriceCazari
                         where cazari.oras == oras

                         select new
                         {

                             datap = cazari.data_plecare,
                             datav = cazari.data_venire,
                             oras = cazari.oras,
                             nume = cazari.numeLoc,
                             buget = cazari.buget

                         };
            var final = result.AsEnumerable();
            return final;
        }
       
        public void Create(IstoricCazari entity)
        {
            _context.Set<IstoricCazari>().Add(entity);
        }

        public void CreateRange(IEnumerable<IstoricCazari> entities)
        {
            _context.Set<IstoricCazari>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(IstoricCazari entity)
        {
            _context.Set<IstoricCazari>().Update(entity);
        }
        public async Task<IstoricCazari> GetById(Guid id)
        {
            return await _context.Set<IstoricCazari>().FindAsync(id);
        }
    }
}
