using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridBeyondMarketRates.Data.Entities;

namespace GridBeyondMarketRates.Models
{
    public class MarketPriceMap : CsvHelper.Configuration.ClassMap<MarketPrice>
    {
        public MarketPriceMap()
        {
            Map(m => m.Date).Index(0);
            Map(m => m.MarketPriceEX1).Index(1);
        }
    }
}
