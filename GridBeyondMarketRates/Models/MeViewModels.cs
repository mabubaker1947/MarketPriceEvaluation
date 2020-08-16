using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GridBeyondMarketRates.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}