using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.DbContexts.Travel
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options) { }
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<IdentityUserIdentityRole> IdentityUserIdentityRoles { get; set; }
        public DbSet<IdentityUserToken> IdentityUserTokens { get; set; }
        public DbSet<IdentityUserTokenConfirmation> IdentityUserTokenConfirmations { get; set; }
        public DbSet<IstoricCazari> IstoriceCazari { get; set; }
        public DbSet<IstoricVacante> IstoriceVacante { get; set; }
        public DbSet<IstoricVacanteUser> IstoricVacanteUsers { get; set; }
        public DbSet<IstoricZbor> IstoricZboruri { get; set; }
        public DbSet<Recenzii> RecenziiC { get; set; }
        public DbSet<RecenziiUsers> RecenziiUsersC { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
