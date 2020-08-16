using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Data.Entity;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI.WebControls;
using GridBeyondMarketRates.Models.Contracts;
using GridBeyondMarketRates.Models.ViewModels;
using GridBeyondMarketRates.Data.Entities;
namespace GridBeyondMarketRates.Services.Queries
{
    public class ImportDataReader: IImportDataReader
    {
        private readonly DatabaseContext _dbContext;

        public ImportDataReader(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public StatsModel CalculateStatsData()
        {
            var min = _dbContext.MarketPrices.Min(x => x.MarketPriceEX1);
            var max = _dbContext.MarketPrices.Max(x => x.MarketPriceEX1);
            var avg = _dbContext.MarketPrices.Average(x => x.MarketPriceEX1);
            var totalRecords = _dbContext.MarketPrices.Count();
            var hourlyMaxpriceQuery =
                from mp1 in _dbContext.MarketPrices
                join mp2 in _dbContext.MarketPrices on mp1.Date.GetValueOrDefault().AddMinutes(30) equals mp2.Date
                select new
                {
                    Expensiveprice = mp1.MarketPriceEX1+mp2.MarketPriceEX1,
                    ExpenisveDate = mp1.Date
                    // some assignments here
                };

            // var data = hourlyMaxpriceQuery.ToList();
            var data = _dbContext.MarketPrices.Select(x => x).Where(x => x.MarketPriceEX1.Equals(max)).ToList();

            var statsModel = new StatsModel()
            {
                AvgPrice = avg, MaxPrice = max, MinPrice = min, MostExpensiveHourDate = data[0].Date,
                MostExpensiveHourPrice = data[0].MarketPriceEX1, TotalRecords = totalRecords
            };


            return statsModel;
        }

        public List<MarketPrice> GetMarketPriceData()
        {
            var data = _dbContext.MarketPrices.Select(x => x).ToList();
            return data;
        }
    }
}