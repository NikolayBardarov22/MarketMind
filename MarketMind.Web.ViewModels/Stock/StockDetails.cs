namespace MarketMind.Web.ViewModels.Stock
{
    using MarketMind.Data.Models;
    using MarketMind.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class StockDetailsViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String? ImageUrl { get; set; }
        public String Symbol { get; set; } = null!;
        public int SectorId { get; set; }
        public virtual ICollection<NewsInfoViewModel> StockNews { get; set; }
            = new HashSet<NewsInfoViewModel>();
        public virtual ICollection<AnalysisInfoViewModel> StockAnalysis { get; set; }
            = new HashSet<AnalysisInfoViewModel>();
    }
    public class NewsInfoViewModel
    {
          public int Id { get; set; } 
          public String AuthorId { get; set; } = null!; 
        public String Title { get; set; } = null!;
        public String Content { get; set; } = null!;
        public DateTime PublishedOn { get; set; }
        public String? ImageUrl { get; set; }
        public String AuthorName { get; set; } = null!;
    }
    public class AnalysisInfoViewModel
    {
        public int Id { get; set; }
        public String AuthorId { get; set; } = null!;
        public String Title { get; set; } = null!; 
        public String Content { get; set; } = null!;
        public Recommendation Recommendation { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public String AuthorName { get; set; } = null!;
    }

}
