using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GridBeyondMarketRates.Data.Entities;
using GridBeyondMarketRates.Models.Contracts;
using GridBeyondMarketRates.Models.ViewModels;

namespace GridBeyondMarketRates.Services
{
    /// <summary>
    ///  stats calculator service
    /// </summary>
    public class StatsCalculatorService
    {
        /// <summary>
        /// data import reader
        /// </summary>
        private readonly IImportDataReader _importDataReader;

        /// <summary>
        /// Stats calculator service
        /// </summary>
        /// <param name="importDataReader"></param>
        public StatsCalculatorService(IImportDataReader importDataReader)
        {
            _importDataReader = importDataReader;
        }

        /// <summary>
        /// calculate stats data
        /// </summary>
        /// <returns></returns>
        public StatsModel CalculateStatsData()
        { 
            return _importDataReader.CalculateStatsData();
        }

        /// <summary>
        /// Get data to display for the chart
        /// </summary>
        /// <returns></returns>
        public List<MarketPrice> GetDataForChart()
        {
            return _importDataReader.GetMarketPriceData();
        }
    }
}