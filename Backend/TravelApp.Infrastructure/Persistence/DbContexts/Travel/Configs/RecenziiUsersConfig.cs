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
    class RecenziiUsersConfig : IEntityTypeConfiguration<RecenziiUsers>
    {
        public void Configure(EntityTypeBuilder<RecenziiUsers> builder)
        {
            builder.ToTable(nameof(RecenziiUsers));
            builder.HasKey(ur => new { ur.UserId, ur.IdMesaj });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.RecenziiUsers)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Recenzii)
                .WithMany(r => r.RecenziiUsers)
                .HasForeignKey(ur => ur.IdMesaj);
        }
    }
}
