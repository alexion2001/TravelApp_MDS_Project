using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;
using TravelApp.Application.Common.Interfaces;

namespace TravelApp.Infrastructure.Services.Managers.Recenzii
{
    public class RecenziiManager : IRecenziiManager
    {
        private readonly TravelDbContext _context;
        public RecenziiManager(TravelDbContext context)
        {
            _context = context;

        }
        public void Create(Domain.Entities.Recenzii entity)
        {
            _context.Set<Domain.Entities.Recenzii>().Add(entity);
        }

        public void CreateRange(IEnumerable<Domain.Entities.Recenzii> entities)
        {
            _context.Set<Domain.Entities.Recenzii>().AddRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(Domain.Entities.Recenzii entity)
        {
            _context.Set<Domain.Entities.Recenzii>().Update(entity);
        }
        public async Task<Domain.Entities.Recenzii> GetById(Guid id)
        {
            return await _context.Set<Domain.Entities.Recenzii>().FindAsync(id);
        }
        public void Delete(Domain.Entities.Recenzii entity)
        {
            _context.Set<Domain.Entities.Recenzii>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<Domain.Entities.Recenzii> entities)
        {
            _context.Set<Domain.Entities.Recenzii>().RemoveRange(entities);
        }

       public async  Task<List<Domain.Entities.Recenzii>> GetAllRec()
       {
           return await _context.RecenziiC.ToListAsync();

       }
       
    }
}
