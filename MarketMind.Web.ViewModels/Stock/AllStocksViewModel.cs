namespace MarketMind.Web.ViewModels.Stock
{
    using MarketMind.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMindGCommon.ValidationConstants.StockValidationConstants;
    public class AllStocksViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StockNameMaxLength)]
        [MinLength(StockNameMinLength)]
        public String Name { get; set; } = null!;

        [Required]
        [MaxLength(StockSymbolMaxLength)]
        [MinLength(StockSymbolMinLength)]
        public String Symbol { get; set; } = null!;

        public String? ImageUrl { get; set; }
        public int SectorId { get; set; }
    }
}
