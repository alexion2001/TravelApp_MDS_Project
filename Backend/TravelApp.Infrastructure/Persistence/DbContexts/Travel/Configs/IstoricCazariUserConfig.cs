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
    public class IstoricCazariUserConfig : IEntityTypeConfiguration<CazariUsers>
    {
        public void Configure(EntityTypeBuilder<CazariUsers> builder)
        {
            builder.ToTable(nameof(CazariUsers));
            builder.HasKey(ur => new { ur.UserId, ur.CazareId });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.CazariUsers)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(ur => ur.IstoricCazari)
                .WithMany(u => u.CazariUsers)
                .HasForeignKey(u => u.CazareId);


        }
    }
}
