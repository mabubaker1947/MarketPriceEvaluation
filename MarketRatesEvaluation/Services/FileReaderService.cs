using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MarketRatesEvaluation.Models;
using MarketRatesEvaluation.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MarketRatesEvaluation.Services
{
    public class FileReaderService
    {
        public FileReaderService()
        {

        }
        public string PopulateCSVToEntity()
        {
            try
            {
                string inputFilePath = "C:\\Users\\mabubaker\\source\\repos\\MarketPriceEvaluation\\MarketRatesEvaluation\\InputFiles\\sampleSheet.csv";
                string SqlConnection = "Data Source =.; Initial Catalog=GridBeyond; Integrated Security = True";// Environment.GetEnvironmentVariable("SqlConnectionString", EnvironmentVariableTarget.Process);
                string fileAllText = ReadFileUtility.ReadAllText(inputFilePath);

                // parsing could have been done via an external library i.e. csvHelper
                // however, i am doing this by hand
                string[] allRows = fileAllText.Split('\n');

                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                optionsBuilder.UseSqlServer(SqlConnection);

                // Go through the CSV Files and insert it into the database.
                using (var db = new DatabaseContext(optionsBuilder.Options))
                {
                    var dataWithoutHeader = allRows.Skip(1);
                    foreach (var row in dataWithoutHeader)
                    {
                        string[] columns = row.Split(',');
                        
                        db.MarketPrice.Add(new MarketPrice(){
                            Date = DateTime.Parse(columns[0]),
                            MarketPriceEX1 = Double.Parse(columns[1])
                        });
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return $"Failed to parse CSV file, Error was \t:{ex.Message}";
            }
            return $"Data parsed successfully";
        }
    }
}
