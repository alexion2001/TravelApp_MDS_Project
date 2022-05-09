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
    class IstoricZborUserConfig : IEntityTypeConfiguration<IstoricZborUser>
    {
        public void Configure(EntityTypeBuilder<IstoricZborUser> builder)
        {
            builder.ToTable(nameof(IstoricZborUser));
            builder.HasKey(ur => new { ur.UserId, ur.ZborId });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.IstoricZborUsers)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.IstoricZbor)
                .WithMany(r => r.IstoricZborUsers)
                .HasForeignKey(ur => ur.ZborId);
        }
    }
}
