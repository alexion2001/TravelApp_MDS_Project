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
    class IstoricZborUserConfig : IEntityTypeConfiguration<ZboruriUsers>
    {
        public void Configure(EntityTypeBuilder<ZboruriUsers> builder)
        {
            builder.ToTable(nameof(ZboruriUsers));
            builder.HasKey(ur => new { ur.UserId, ur.ZborId });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.ZboruriUsers)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(ur => ur.IstoricZbor)
                .WithMany(u => u.ZboruriUsers)
                .HasForeignKey(u => u.ZborId);

        }
    }
    }
