using MarketMind.Services.Core.Contracts;
using MarketMind.Web.ViewModels.Stock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketMind.Controllers
{
    public class StockController : BaseController
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AddStockInputViewModel? model = new AddStockInputViewModel
            {
                Sectors = await this.stockService.GetAllSectorsAsync()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStockInputViewModel model)
        {
            var sectors = await this.stockService.GetAllSectorsAsync();

            if (!sectors.Any(s => s.Id == model.SectorId))
            {
                ModelState.AddModelError(nameof(model.SectorId), "Sector does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Sectors = sectors;
                return View(model);
            }

            await this.stockService.CreateAsync(model);

          
            return RedirectToAction("Index", "Home");
        }
    }
}
