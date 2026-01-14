namespace MarketMind.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMind.Data.Common.EntityValidations.StockEntityValidations;
    public class Stock
    {
        private String _symbol = null!;
        public int Id { get; set; }


        [MinLength(StockNameMinLength)]
        public String Name { get; set; } = null!;

        [MinLength(StockSymbolMinLength)]
        public required String Symbol
        {
            get { return this._symbol; }
            set
            {
                this._symbol = value.ToUpper();
            }
        }
        public String? ImageUrl { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; } = null!;

        //TODO: Format constant for datetimes
        public DateTime CreatedOn { get; set; }
        public virtual ICollection<StockNews> StockNews { get; set; } = new HashSet<StockNews>();
        public virtual ICollection<StockAnalysis> StockAnalysis { get; set; } = new HashSet<StockAnalysis>();
        public virtual ICollection<WatchlistItem> WatchlistItems { get; set; } = new HashSet<WatchlistItem>();
    }
}
