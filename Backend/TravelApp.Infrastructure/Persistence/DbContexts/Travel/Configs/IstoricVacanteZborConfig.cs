using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
   public class IstoricVacanteZborConfig : IEntityTypeConfiguration<IstoricVacante>
    {
        
        public void Configure(EntityTypeBuilder<IstoricVacante> builder)
        {

            builder.ToTable(nameof(IstoricVacante));
            builder.HasKey(prop => prop.VacantaId);
            builder.HasOne(prop => prop.Zbor)
                .WithOne(v => v.IstoricVacante)
                .HasForeignKey<IstoricZbor>(prop => prop.Id);

           
        }
    }
}
