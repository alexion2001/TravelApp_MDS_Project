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
        public async Task<IstoricZbor> GetIstoricZbor(Guid Id)
        {
            var zbor = await _context.IstoricZboruri.Where(u => u.Id.Equals(Id)).SingleOrDefaultAsync();
            return zbor;

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
        public void Update(IstoricZbor entity)
        {
            _context.Set<IstoricZbor>().Update(entity);
        }
        public async Task<IstoricZbor> GetById(Guid id)
        {
            return await _context.Set<IstoricZbor>().FindAsync(id);
        }
    }
}
