namespace MarketMind.Web.ViewModels.StockNews
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class StockNewsDetailsViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; } = null!;
        public String Content { get; set; } = null!;
        public DateTime PublishedOn { get; set; }
        public int StockId { get; set; }
        public String? ImageUrl { get; set; }
        public String AuthorId { get; set; } = null!;
        public String AuthorName { get; set; } = null!;
    }
}
