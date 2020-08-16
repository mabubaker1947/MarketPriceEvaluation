using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GridBeyondMarketRates.Data.Entities;
using GridBeyondMarketRates.Models.Contracts;
using GridBeyondMarketRates.Models.ViewModels;

namespace GridBeyondMarketRates.Services
{
    public class StatsCalculatorService
    {
        private readonly IImportDataReader _importDataReader;
        public StatsCalculatorService(IImportDataReader importDataReader)
        {
            _importDataReader = importDataReader;
        }

        public StatsModel CalculateStatsData()
        { 
            return _importDataReader.CalculateStatsData();
        }

        public List<MarketPrice> GetDataForChart()
        {
            return _importDataReader.GetMarketPriceData();
        }
    }
}