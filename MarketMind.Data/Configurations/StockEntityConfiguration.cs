namespace MarketMind.Data.Configurations
{
    using MarketMind.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMind.Data.Common.EntityValidations.StockEntityValidations;

    public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(StockNameMaxLength)
                .IsRequired();

            entity.Property(e => e.Symbol)
                .HasMaxLength(StockSymbolMaxLength)
                .IsRequired();

            entity.HasOne(e => e.Sector)
                .WithMany(e => e.Stocks)
                .HasForeignKey(e => e.SectorId);

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
