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
    class IstoricZborUserConfig : IEntityTypeConfiguration<IstoricZbor>
    {
        public void Configure(EntityTypeBuilder<IstoricZbor> builder)
        {
            builder.ToTable(nameof(IstoricZbor));
            builder.HasKey(ur => new { ur.Id });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.IstoricZboruri)
                .HasForeignKey(u => u.IdUser);

        }
    }
    }
