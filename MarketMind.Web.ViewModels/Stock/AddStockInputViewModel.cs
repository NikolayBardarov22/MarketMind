namespace MarketMind.Web.ViewModels.Stock
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMindGCommon.ValidationConstants.StockValidationConstants;
    public class AddStockInputViewModel
    {
        [Required]
        [StringLength(StockNameMaxLength, MinimumLength = StockNameMinLength,
           ErrorMessage = "Name must be between {2} and {1} characters.")]
        public String Name { get; set; } = null!;

        [Required]
        [StringLength(StockSymbolMaxLength, MinimumLength = StockSymbolMinLength,
            ErrorMessage = "Symbol must be between {2} and {1} characters.")]
        public string Symbol { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Sector")]
        public int SectorId { get; set; }
        public IEnumerable<StockSectorViewModel> Sectors { get; set; } = new List<StockSectorViewModel>();
    }
}
