using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMind.Data.Common
{
    public static class EntityValidations
    {
        public static class StockEntityValidations
        {
            public const int StockNameMaxLength = 70;
            public const int StockNameMinLength = 1;

            public const int StockSymbolMaxLength = 6;
            public const int StockSymbolMinLength = 1;
        }
        public static class SectorEntityValidations
        {
            public const int SectorNameMinLength = 3;
            public const int SectorNameMaxLength = 40;

            public const int SectorDescriptionMaxLength = 250;
            public const int SectorDescriptionMinLength = 20;
        }
        public static class StockNewsEntityValidations
        {
            public const int StockNewsTitleMaxLength = 70;
            public const int StockNewsTitleMinLength = 3;

            public const int StockNewsContentMinLength = 40;
            public const int StockNewsContentMaxLength = 3000;
        }

        public static class StockAnalysisEntityValidations
        {
            public const int StockAnalysisTitleMaxLength = 50;
            public const int StockAnalysisTitleMinLength = 3;

            public const int StockAnalysisContentMinLength = 40;
            public const int StockAnalysisContentMaxLength = 2500;
        }
    }
}
