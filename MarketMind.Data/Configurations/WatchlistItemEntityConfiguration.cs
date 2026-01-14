namespace MarketMind.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders; 
    using MarketMind.Data.Models;
    public class WatchlistItemEntityConfiguration : IEntityTypeConfiguration<WatchlistItem>
    {
        public void Configure(EntityTypeBuilder<WatchlistItem> entity)
        {
            entity.HasKey(e => new { e.UserId, e.StockId });

            entity.HasOne(e => e.Stock)
                .WithMany(e => e.WatchlistItems)
                .HasForeignKey(e => e.StockId);

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.AddedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
