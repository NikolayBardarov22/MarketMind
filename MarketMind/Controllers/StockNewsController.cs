namespace MarketMind.Controllers
{
    using MarketMind.Services.Core;
    using MarketMind.Services.Core.Contracts;
    using MarketMind.Web.ViewModels.Stock;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using MarketMind.Web.ViewModels.StockNews;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;

    [Authorize]
    public class StockNewsController : BaseController
    {
        private readonly IStockNewsService _stockNewsService;

        public StockNewsController(IStockNewsService stockNewsService)
        {
            _stockNewsService = stockNewsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int stockId)
        {
            try
            {
                bool exist = await this._stockNewsService.StockExistAsync(stockId);
                if (!exist)
                {
                    return NotFound();
                }

                AddStockNewsInputModel? model = new AddStockNewsInputModel()
                {
                    StockId = stockId,
                };

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStockNewsInputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool stockExist = await _stockNewsService.StockExistAsync(model.StockId);
            if (!stockExist)
            {
                ModelState
                    .AddModelError(String.Empty, "This stock does not exist anymore. Please try again.");
                return View(model);
            }
            String? authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _stockNewsService.CreateStockNewsAsync(model, authorId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return View(model);
            }
            return RedirectToAction("Details", "Stock", new { id = model.StockId });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            StockNewsDetailsViewModel model = await this._stockNewsService.GetStockNewsDetailsByIdAsync(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditStockNewsInputModel? model = await this._stockNewsService.GetStockNewsToEditByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            String? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (model.AuthorId != currentUserId) return Unauthorized();

            return View(model);
        }
    }
}
