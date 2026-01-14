namespace MarketMind.Data
{
    using MarketMind.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class MarketMindDbContext : IdentityDbContext
    {
        public MarketMindDbContext(DbContextOptions<MarketMindDbContext> options)
            : base(options)
        {
        }
        public DbSet<Sector> Sectors { get; set; } = null!;
        public DbSet<Stock> Stocks { get; set; } = null!;
        public DbSet<StockNews> StockNews { get; set; } = null!;
        public DbSet<StockAnalysis> StockAnalyses { get; set; } = null!;
        public DbSet<WatchlistItem> WatchlistItems { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
