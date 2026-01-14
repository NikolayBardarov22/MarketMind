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
    using static MarketMind.Data.Common.EntityValidations.StockNewsEntityValidations;
    public class StockNewsEntityConfiguration : IEntityTypeConfiguration<StockNews>
    {
        public void Configure(EntityTypeBuilder<StockNews> entity)
        {

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(StockNewsTitleMaxLength);

            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(StockNewsContentMaxLength);

            entity.HasOne(e => e.Stock)
                .WithMany(e => e.StockNews)
                .HasForeignKey(e => e.StockId);

            entity.HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                 .OnDelete(DeleteBehavior.Restrict); 

            entity.Property(e => e.PublishedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
