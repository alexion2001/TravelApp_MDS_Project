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
    public class IstoricCazariUserConfig : IEntityTypeConfiguration<IstoricCazariUser>
    {
        public void Configure(EntityTypeBuilder<IstoricCazariUser> builder)
        {
            builder.ToTable(nameof(IstoricCazariUser));
            builder.HasKey(ur => new { ur.UserId, ur.Cazareid });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.IstoricCazariUsers)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.IstoricCazari)
                .WithMany(r => r.IstoricCazariUsers)
                .HasForeignKey(ur => ur.Cazareid);
        }
    }
}
