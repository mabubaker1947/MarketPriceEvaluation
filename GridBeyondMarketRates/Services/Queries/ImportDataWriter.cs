using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Web;
using GridBeyondMarketRates.Data.Entities;
using GridBeyondMarketRates.Models.Contracts;
using System.Configuration;

namespace GridBeyondMarketRates.Services.Queries
{
    public class ImportDataWriter:IImportDataWriter
    {
        private readonly DatabaseContext _dbContext;

        public ImportDataWriter(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveImportedDataToDatabase()
        {
            var filepath = ConfigurationManager.AppSettings["FilePath"];
            string fileAllText = ReadFileUtility.ReadAllText(filepath);

            // parsing could have been done via an external library i.e. csvHelper
            // however, i am doing this by hand to elaborate working with complex data in CSV files
            string[] allRows = fileAllText.Split('\n');

            // Go through the CSV Files and insert it into the database.
            using (var db = new DatabaseContext())
            {
                var dataWithoutHeader = allRows.Skip(1);
                foreach (var row in dataWithoutHeader)
                {
                    string[] columns = row.Split(',');

                    db.MarketPrices.Add(new MarketPrice()
                    {
                        Date = DateTime.Parse(columns[0]),
                        MarketPriceEX1 = Double.Parse(columns[1])
                    });
                }
                // save all changes to database via Entity Framework
                db.SaveChanges();
            }
        }
    }
}