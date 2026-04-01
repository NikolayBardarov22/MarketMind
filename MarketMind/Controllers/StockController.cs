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
            try
            {
                String? isUserValid = this.GetUserId();
                if (isUserValid != null)
                {
                    AddStockInputViewModel? model = new AddStockInputViewModel
                    {
                        Sectors = await this.stockService.GetAllSectorsAsync()
                    };

                    return View(model);
                }
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddStockInputViewModel model)
        {
            IEnumerable<StockSectorViewModel>? sectors = await this.stockService.GetAllSectorsAsync();

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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            String? userId = this.GetUserId();

            if (userId != null)
            {
                IEnumerable<AllStocksViewModel> allStocks = await stockService.GetAllStocksAsync(userId);
                return View(allStocks);
            }
            return View("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                StockDetailsViewModel? model = await this.stockService.GetStockDetailsByIdAsync(id);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
