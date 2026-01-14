namespace MarketMind.Data.Models
{
    using MarketMind.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class WatchlistItem
    {
        public String UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;

        public DateTime AddedOn { get; set; }
    }
}
