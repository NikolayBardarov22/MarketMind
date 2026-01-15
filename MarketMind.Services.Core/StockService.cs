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
    }
}
