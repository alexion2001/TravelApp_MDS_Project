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
    public class IdentityUserTokenConfirmationConfig : IEntityTypeConfiguration<IdentityUserTokenConfirmation>
    {
        public void Configure(EntityTypeBuilder<IdentityUserTokenConfirmation> builder)
        {
            builder.ToTable(nameof(IdentityUserTokenConfirmation));
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.ConfirmationToken).IsRequired().HasMaxLength(500);

            builder.HasOne(prop => prop.User)
                .WithMany(prop => prop.IdentityUserTokenConfirmations)
                .HasForeignKey(prop => prop.UserId);
        }
    }
}
