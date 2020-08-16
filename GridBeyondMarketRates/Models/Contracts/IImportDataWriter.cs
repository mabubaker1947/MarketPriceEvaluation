using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridBeyondMarketRates.Models.Contracts
{
    public interface IImportDataWriter
    {
        void SaveImportedDataToDatabase();
    }
}