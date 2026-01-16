using MarketMind.Web.ViewModels.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMind.Services.Core.Contracts
{
    public interface IStockService
    {
        Task<IEnumerable<StockSectorViewModel?>> GetAllSectorsAsync();
        Task CreateAsync(AddStockInputViewModel model);
        Task<IEnumerable<AllStocksViewModel>> GetAllStocksAsync(int stockId);

    }
}
