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
    public class IdentityUserConfig : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.ToTable(nameof(IdentityUser));
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Username).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.Email).IsRequired().HasMaxLength(100);
            builder.Property(prop => prop.PasswordHash).IsRequired().HasMaxLength(500);
            builder.Property(prop => prop.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(prop => prop.PhoneNumberCountryPrefix).IsRequired().HasMaxLength(6);

            //define relations
        
            builder.HasMany(utc => utc.IdentityUserTokenConfirmations).WithOne(u => u.User);
            builder.HasMany(ut => ut.IdentityUserTokens).WithOne(u => u.User);
      

        }
    }
}
