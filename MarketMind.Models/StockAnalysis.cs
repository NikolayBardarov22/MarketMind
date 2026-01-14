namespace MarketMind.Data.Models
{
    using MarketMind.Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static MarketMind.Data.Common.EntityValidations.StockAnalysisEntityValidations;
    public class StockAnalysis
    {
        public int Id { get; set; }

        [MinLength(StockAnalysisTitleMinLength)]
        public String Title { get; set; } = null!;

        [MinLength(StockAnalysisContentMinLength)]
        public String Content { get; set; } = null!;
        public Recommendation Recommendation { get; set; }
        public RiskLevel RiskLevel { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;

        public virtual String AuthorId { get; set; } = null!;
        public virtual IdentityUser Author { get; set; } = null!;
    }
}
