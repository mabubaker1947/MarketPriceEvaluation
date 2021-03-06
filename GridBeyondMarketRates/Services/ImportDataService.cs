﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GridBeyondMarketRates.Data.Entities;
using GridBeyondMarketRates.Models.Contracts;
using GridBeyondMarketRates.Services.Queries;

namespace GridBeyondMarketRates.Services
{
    /// <summary>
    ///  data importer service
    /// </summary>
    public class ImportDataService
    {
        private readonly IImportDataWriter _importDataWriter;
        public ImportDataService(IImportDataWriter importDataWriter)
        {
            _importDataWriter = importDataWriter;
        }

        /// <summary>
        /// Populate CSV data into the Entity
        /// </summary>
        /// <returns></returns>
        public string PopulateCSVToEntity()
        {
            try
            {
                _importDataWriter.SaveImportedDataToDatabase();
            }
            catch (Exception ex)
            {
                return $"Failed to parse CSV file, Error was \t:{ex.Message}";
            }
            return $"Data parsed successfully";
        }
    }
}