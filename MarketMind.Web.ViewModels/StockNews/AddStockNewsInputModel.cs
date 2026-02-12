namespace MarketMind.Web.ViewModels.StockNews
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMindGCommon.ValidationConstants.StockNewsValidationConstants;
    public class AddStockNewsInputModel
    {
        [Required] 
        [StringLength(StockNewsTitleNameMaxLength, MinimumLength = StockNewsTitleNameMinLength)]
        public String Title { get; set; } = null!;

        [Required]
        [StringLength(StockNewsContentMaxLength, MinimumLength = StockNewsContentMinLength)]
        public String Content { get; set; } = null!;

        [Display(Name = "Image URL")] 
        [Url]
        public String? ImageUrl { get; set; } 

        public int StockId { get; set; }
    }
}
