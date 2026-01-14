namespace MarketMind.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMind.Data.Common.EntityValidations.StockNewsEntityValidations;
    public class StockNews
    {
        public int Id { get; set; }

        [MinLength(StockNewsTitleMinLength)]
        public String Title { get; set; } = null!;

        [MinLength(StockNewsContentMinLength)]
        public String Content { get; set; } = null!;

        //TODO: Format constant for datetimes
        public DateTime PublishedOn { get; set; }
        public int StockId { get; set; }
        public String? ImageUrl { get; set; }
        public Stock Stock { get; set; } = null!;
        public String AuthorId { get; set; } = null!;
        public virtual IdentityUser Author { get; set; } = null!;
    }
}
