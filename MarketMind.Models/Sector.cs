namespace MarketMind.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Sector
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public virtual ICollection<Stock> Stocks { get; set; } = new HashSet<Stock>();
    }
}
