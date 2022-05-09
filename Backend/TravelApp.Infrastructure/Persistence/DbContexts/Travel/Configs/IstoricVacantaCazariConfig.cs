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
    class IstoricVacantaCazariConfig : IEntityTypeConfiguration<IstoricVacante>
    {

        public void Configure(EntityTypeBuilder<IstoricVacante> builder)
        {

            builder.ToTable(nameof(IstoricVacante));
            builder.HasKey(prop => prop.VacantaId);
            builder.HasOne(prop => prop.Cazari)
                .WithOne(prop => prop.IstoricVacanta)
                .HasForeignKey<IstoricCazari>(prop => prop.Id);


        } 
    }
}
