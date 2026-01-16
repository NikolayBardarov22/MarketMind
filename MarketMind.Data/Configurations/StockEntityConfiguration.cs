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

            // entity.HasData(this.GetStocksForSeeding());
        }
        //private HashSet<Stock> GetStocksForSeeding()
        //{
        //    HashSet<Stock> seedStocks = new HashSet<Stock>()
        //    {
        //        new Stock { Id = 1, Name = "Exxon Mobil Corp.", Symbol = "xom", SectorId = 1, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 2, Name = "Linde plc", Symbol = "lin", SectorId = 2, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 3, Name = "Caterpillar Inc.", Symbol = "cat", SectorId = 3, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 4, Name = "Amazon.com Inc.", Symbol = "amzn", SectorId = 4, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 5, Name = "Walmart Inc.", Symbol = "wmt", SectorId = 5, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 6, Name = "UnitedHealth Group Inc.", Symbol = "unh", SectorId = 6, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 7, Name = "Goldman Sachs Group", Symbol = "gs", SectorId = 7, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 8, Name = "Apple Inc.", Symbol = "aapl", SectorId = 8, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 9, Name = "Microsoft Corporation", Symbol = "msft", SectorId = 8, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 10, Name = "Meta Platforms Inc.", Symbol = "meta", SectorId = 9, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 11, Name = "NextEra Energy Inc.", Symbol = "nee", SectorId = 10, CreatedOn = DateTime.UtcNow },
        //        new Stock { Id = 12, Name = "American Tower Corp.", Symbol = "amt", SectorId = 11, CreatedOn = DateTime.UtcNow }
        //    };
        //    return seedStocks;
        //}
    }
}

