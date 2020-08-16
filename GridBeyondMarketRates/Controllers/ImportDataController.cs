using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GridBeyondMarketRates.Data.Entities;
using GridBeyondMarketRates.Models.Contracts;
using GridBeyondMarketRates.Models.ViewModels;
using GridBeyondMarketRates.Services;
using GridBeyondMarketRates.Services.Queries;

namespace GridBeyondMarketRates.Controllers
{
    /// <summary>
    /// Controller for Importing data 
    /// </summary>
    public class ImportDataController : Controller
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();
        public ImportDataController()
        {

        }

        // GET: ImportData
        public Task<ActionResult> Index()
        {
            return DoTask(_ =>
            {
                //var fileReaderService = new FileReaderService();
                //fileReaderService.PopulateCSVToEntity();
                var model = new StatsModel();
                var importDataReader = new ImportDataReader(_dbContext);
                var statsCalculator = new StatsCalculatorService(importDataReader);
                model = statsCalculator.CalculateStatsData();
                return View(model);
            });
        }

        // GET: ImportData
        public Task<ActionResult> Import()
        {
            return DoTask(_ =>
            {
                var importDataWriter = new ImportDataWriter(_dbContext);
                var importDataReader = new ImportDataReader(_dbContext);

                var fileReaderService = new ImportDataService(importDataWriter);
                fileReaderService.PopulateCSVToEntity();
                var statsCalculator = new StatsCalculatorService(importDataReader);
                var model = statsCalculator.CalculateStatsData();
                return View("Index",model);
            });
        }

        /// <summary>
        /// Display the time series data into the chart
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult> Details()
        {
            return DoTask(_=>
            {
                var importDataReader = new ImportDataReader(_dbContext);
                var statsCalculator = new StatsCalculatorService(importDataReader);
                var model = statsCalculator.GetDataForChart();
                return View("Details", model);
            });
        }

        /// <summary>
        /// Starts a new task with performs the specified actions in <paramref name="function"/> but
        /// wraps it in our standard error handling to allow for neater use.
        /// </summary>
        /// <param name="function">The function to perform in a <seealso cref="Task"/>.</param>
        /// <param name="errorMessage">The message to log in event of an error.</param>
        /// <param name="args">The arguments to format the message with.</param>
        /// <returns>A new instance of <seealso cref="Task"/> that will perform the
        /// code specified in <paramref name="function"/>.</returns>
        protected Task<ActionResult> DoTask(Func<HttpContextBase, ActionResult> function, string errorMessage = "Error default", params object[] args)
        {
            return Task.Factory.StartNew(context =>
            {
                try
                {
                    return function((HttpContextBase)context);
                }
                catch (Exception ex)
                {
                    // log and return an error response rather than hitting the application's
                    // error handler - we've dealt with it here.
                    //_logger.Error(ex, errorMessage, args);
                    return new HttpStatusCodeResult(500 /*server error*/);
                }
            }, HttpContext);
        }
    }
}
