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
    using static MarketMind.Data.Common.EntityValidations.StockAnalysisEntityValidations;
    public class StockAnalysisEntityConfiguration : IEntityTypeConfiguration<StockAnalysis>
    {
        public void Configure(EntityTypeBuilder<StockAnalysis> entity
            )
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(StockAnalysisTitleMaxLength);

            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(StockAnalysisContentMaxLength);

            entity.HasOne(e => e.Stock)
                .WithMany(e => e.StockAnalysis)
                .HasForeignKey(e => e.StockId);

            entity.HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
