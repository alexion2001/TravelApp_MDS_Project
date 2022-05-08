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
    public class IdentityUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken> builder)
        {
            builder.ToTable(nameof(IdentityUserToken));
            builder.HasKey(ut => ut.Id);

            builder.Property(prop => prop.RefreshTokenValue).HasMaxLength(800);
            builder.Property(prop => prop.TokenValue).IsRequired().HasMaxLength(800);

            builder.HasOne(u => u.User)
                .WithMany(ut => ut.IdentityUserTokens)
                .HasForeignKey(ut => ut.UserId);
        }
    }
}
