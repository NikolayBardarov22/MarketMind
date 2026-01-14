using MarketMind.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace MarketMind.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMind.Data.Common.EntityValidations.SectorEntityValidations;
    public class SectorEntityConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(SectorNameMaxLength);
        }
    }
}
