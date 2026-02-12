using MarketMind.Web.ViewModels.Stock;
using MarketMind.Web.ViewModels.StockNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMind.Services.Core.Contracts
{
    public interface IStockNewsService
    {
        Task<bool> StockExistAsync(int stockId);
        Task CreateStockNewsAsync(AddStockNewsInputModel model, String? authorId);

    }
}
