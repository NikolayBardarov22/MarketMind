namespace MarketMind.Services.Core
{
    using MarketMind.Data;
    using MarketMind.Data.Models;
    using MarketMind.Services.Core.Contracts;
    using MarketMind.Web.ViewModels.Stock;
    using MarketMind.Web.ViewModels.StockNews;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class StockNewsService : IStockNewsService
    {
        private readonly MarketMindDbContext marketMindDbContext;

        public StockNewsService(MarketMindDbContext marketMindDbContext)
        {
            this.marketMindDbContext = marketMindDbContext;
        }

        public async Task CreateStockNewsAsync(AddStockNewsInputModel model, String? authorId)
        {
            if (String.IsNullOrEmpty(authorId))
                throw new ArgumentNullException(nameof(authorId), "Author Id cannot be null or empty.");

            StockNews newStocArticle = new StockNews()
            {
                Title = model.Title,
                Content = model.Content,
                PublishedOn = DateTime.UtcNow,
                StockId = model.StockId,
                ImageUrl = model.ImageUrl,
                AuthorId = authorId
            };
            await marketMindDbContext.StockNews.AddAsync(newStocArticle);
            await marketMindDbContext.SaveChangesAsync();
        }

        public async Task<StockNewsDetailsViewModel?> GetStockNewsDetailsByIdAsync(int id)
        {
            return await marketMindDbContext.StockNews
                .Where(n => n.Id == id)
                .AsNoTracking()
                .Select(n => new StockNewsDetailsViewModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PublishedOn = DateTime.UtcNow,
                    StockId = n.StockId,
                    ImageUrl = n.ImageUrl,
                    AuthorId = n.AuthorId,
                    AuthorName = n.Author.UserName ?? string.Empty,
                }).FirstOrDefaultAsync();
        }

        public async Task<EditStockNewsInputModel?> GetStockNewsToEditByIdAsync(int id)
        {
            return await this.marketMindDbContext.StockNews
                .Where(n => n.Id == id)
                .AsNoTracking()
                .Select(n => new EditStockNewsInputModel()
                {
                    Id = id,
                    Title = n.Title,
                    Content = n.Content,
                    ImageUrl = n.ImageUrl,
                    StockId = n.StockId,
                    AuthorId = n.AuthorId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> StockExistAsync(int stockId)
        {
            return await this.marketMindDbContext.Stocks.AnyAsync(s => s.Id == stockId);
        }
    }
}
