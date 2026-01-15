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

            entity.HasData(this.GenerateSeedSectors());
        }
        private HashSet<Sector> GenerateSeedSectors()
        {
            HashSet<Sector> seedSectors = new HashSet<Sector>()
            {
                new Sector { Id = 1, Name = "Energy" },
                new Sector { Id = 2, Name = "Materials" },
                new Sector { Id = 3, Name = "Industrials" },
                new Sector { Id = 4, Name = "Consumer Discretionary" },
                new Sector { Id = 5, Name = "Consumer Staples" },
                new Sector { Id = 6, Name = "Health Care" },
                new Sector { Id = 7, Name = "Financials" },
                new Sector { Id = 8, Name = "Information Technology" },
                new Sector { Id = 9, Name = "Communication Services" },
                new Sector { Id = 10, Name = "Utilities" },
                new Sector { Id = 11, Name = "Real Estate" }
            };
            return seedSectors;
        }
    }
}
