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
    public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserIdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityUserIdentityRole> builder)
        {
            builder.ToTable(nameof(IdentityUserIdentityRole));
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.IdentityUser)
                .WithMany(u => u.IdentityUserRoles)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.IdentityRole)
                .WithMany(r => r.IdentityUserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
