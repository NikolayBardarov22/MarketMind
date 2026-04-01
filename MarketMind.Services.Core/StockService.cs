using MarketMind.Data;
using MarketMind.Data.Models;
using MarketMind.Services.Core.Contracts;
using MarketMind.Web.ViewModels.Stock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMind.Services.Core
{
    public class StockService : IStockService
    {
        private readonly MarketMindDbContext marketMindDbContext;

        public StockService(MarketMindDbContext marketMindDbContext)
        {
            this.marketMindDbContext = marketMindDbContext;
        }
        public async Task CreateAsync(AddStockInputViewModel model)
        {
            Stock? stock = new Stock
            {
                Name = model.Name,
                Symbol = model.Symbol,
                ImageUrl = model.ImageUrl,
                SectorId = model.SectorId,
                CreatedOn = DateTime.UtcNow
            };

            await this.marketMindDbContext.Stocks.AddAsync(stock);
            await this.marketMindDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockSectorViewModel>> GetAllSectorsAsync()
        {
            return await this.marketMindDbContext
                .Sectors
                .AsNoTracking()
                .Select(s => new StockSectorViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToArrayAsync();
        }

        public async Task<IEnumerable<AllStocksViewModel>> GetAllStocksAsync(String? userId)
        {
            IEnumerable<AllStocksViewModel> allStocks = await marketMindDbContext
                .Stocks
                .AsNoTracking()
                .Select(s => new AllStocksViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Symbol = s.Symbol,
                    ImageUrl = s.ImageUrl,
                    SectorId = s.SectorId
                })
                .ToArrayAsync();
            return allStocks;
        }

        public async Task<StockDetailsViewModel> GetStockDetailsByIdAsync(int stockId)
        {
            StockDetailsViewModel stockDetail = null;

            Stock? stock = await this.marketMindDbContext
                .Stocks
                .Include(s => s.StockNews)
                .ThenInclude(n => n.Author)
                .Include(s => s.StockAnalysis)
                .ThenInclude(a => a.Author)
                .AsNoTracking()
                 .AsSplitQuery()
                .FirstOrDefaultAsync(s => s.Id == stockId);
            if (stock == null) return null;

            stockDetail = new StockDetailsViewModel()
            {
                Id = stock.Id,
                Name = stock.Name,
                Symbol = stock.Symbol,
                ImageUrl = stock.ImageUrl,
                SectorId = stock.SectorId,

                StockNews = stock.StockNews.Select(n => new NewsInfoViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl,
                    AuthorName = n.Author.UserName ?? "N/A"
                }).ToArray(),

                StockAnalysis = stock.StockAnalysis.Select(a => new AnalysisInfoViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Recommendation = a.Recommendation,
                    RiskLevel = a.RiskLevel,
                    AuthorName = a.Author.UserName ?? "N/A"
                }).ToArray()
            };
            return stockDetail;
        }
    }
}
