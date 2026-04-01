namespace MarketMindGCommon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ValidationConstants
    {
        public static class StockValidationConstants
        {
            public const int StockNameMaxLength = 70;
            public const int StockNameMinLength = 1;

            public const int StockSymbolMaxLength = 6;
            public const int StockSymbolMinLength = 1;
        }

        public static class StockNewsValidationConstants
        {
            public const int StockNewsTitleNameMaxLength = 70;
            public const int StockNewsTitleNameMinLength = 3;

            public const int StockNewsContentMaxLength = 6000;
            public const int StockNewsContentMinLength = 10;


        }
    }
}
/*

        //TODO: Format constant for datetimes
        public DateTime PublishedOn { get; set; }
        public int StockId { get; set; }
        public String? ImageUrl { get; set; }
        public Stock Stock { get; set; } = null!;
        public String AuthorId { get; set; } = null!;
        public virtual IdentityUser Author { get; set; } = null!;
 
 
 
 */