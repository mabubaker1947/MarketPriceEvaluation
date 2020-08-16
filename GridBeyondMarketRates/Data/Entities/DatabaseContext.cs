using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GridBeyondMarketRates.Data.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext():base("name=GridBeyondMarketRatesContext")
        {
        }

        public DbSet<MarketPrice> MarketPrices { get; set; }
    }
}
