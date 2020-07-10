using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketRatesEvaluation.Models.Entities
{
    public class MarketPrice
    {
        [Key]
        public int Id { get; set; } // int, not null
        public DateTime? Date { get; set; } // datetime, null
        public double MarketPriceEX1 { get; set; }
    }
}
