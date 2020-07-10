using System;
using System.Globalization;
using System.IO;
using MarketRatesEvaluation.Models;
using MarketRatesEvaluation.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketRatesEvaluation.Services
{
    public class FileReaderService
    {
        public string PopulateCSVToEntity(string file)
        {
            try
            {
                // Go through the CSV Files and insert it into the database.

                string inputFilePath = Environment.GetEnvironmentVariable("InputFilePath");

                using var fileReader = new StreamReader(file);
                using var csvReader = new CsvHelper.CsvReader(fileReader, CultureInfo.InvariantCulture);

                csvReader.Configuration.HasHeaderRecord = false;
                csvReader.Configuration.RegisterClassMap<MarketPlaceMap>();

                string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");

                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                optionsBuilder.UseSqlServer(SqlConnection);

                using (var db = new DatabaseContext(optionsBuilder.Options))
                {

                    // Each line in the CSV is a seat. O.O
                    foreach (MarketPrice marketPrice in csvReader.GetRecords<MarketPrice>())
                    {
                        db.MarketPrices.Add(marketPrice);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return $"Failed to parse CSV Error was \t:{ex.Message}";
            }
            return $"Data parsed successfully";
        }
    }
}
