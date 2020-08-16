using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridBeyondMarketRates.Models.ViewModels
{
    public class StatsModel
    {
        /// <summary>
        /// Example of data annotation
        /// </summary>
        public int TotalRecords { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public double AvgPrice { get; set; }
        public DateTime? MostExpensiveHourDate { get; set; }

        public double MostExpensiveHourPrice { get; set; }
    }
}