namespace MarketMind.Web.ViewModels.StockNews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EditStockNewsInputModel : AddStockNewsInputModel
    {
        public int Id { get; set; }
        public String AuthorId { get; set; } = null!;
    }
}
