using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GridBeyondMarketRates.Data.Entities;
using GridBeyondMarketRates.Models.ViewModels;

namespace GridBeyondMarketRates.Models.Contracts
{
    public interface IImportDataReader
    {
        StatsModel CalculateStatsData();
        List<MarketPrice> GetMarketPriceData();
    }
}