using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Infrastructure.Persistence.DbContexts.Travel.Configs
{
    class IstoricVacanteUserConfig : IEntityTypeConfiguration<IstoricVacanteUser>
    {
        public void Configure(EntityTypeBuilder<IstoricVacanteUser> builder)
        {
            builder.ToTable(nameof(IstoricVacanteUser));
            builder.HasKey(ur => new { ur.UserId, ur.Vacantaid });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.IstoricVacanteUsers)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.IstoricVacante)
                .WithMany(r => r.IstoricVacanteUsers)
                .HasForeignKey(ur => ur.Vacantaid);
        }
    }
}