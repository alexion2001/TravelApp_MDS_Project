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
    public class IstoricCazariUserConfig : IEntityTypeConfiguration<IstoricCazari>
    {
        public void Configure(EntityTypeBuilder<IstoricCazari> builder)
        {
            builder.ToTable(nameof(IstoricCazari));
            builder.HasKey(ur => new { ur.Id });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.IstoricCazariU)
                .HasForeignKey(u => u.IdUser);


        }
    }
}
