using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using MarketRatesEvaluation.Services;
using MarketRatesEvaluation.Views.InputFileHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketRatesEvaluation.Controllers
{
    public class InputFileHandler : Controller
    {
        // GET: InputFileHandler
        public ActionResult Index()
        {
            //return DoTask(_ =>
            //{
                var fileReaderService = new FileReaderService();
                fileReaderService.PopulateCSVToEntity();
                var model = new DetailsModel();
                return View(model);
            //});

            //Task.Factory.StartNew(context =>
            //{
            //    try
            //    {
            //        var fileReaderService = new FileReaderService();
            //        fileReaderService.PopulateCSVToEntity();
            //        var model = new DetailsModel();
            //        return View(model);
            //    }
            //    catch (Exception ex)
            //    {
            //        // log and return an error response rather than hitting the application's
            //        // error handler - we've dealt with it here.
            //        //_logger.Error(ex, errorMessage, args);
            //        //return new (500 /*server error*/);
            //    }
            //});

        }

        ///// <summary>
        ///// Starts a new task with performs the specified actions in <paramref name="function"/> but
        ///// wraps it in our standard error handling to allow for neater use.
        ///// </summary>
        ///// <param name="function">The function to perform in a <seealso cref="Task"/>.</param>
        ///// <param name="errorMessage">The message to log in event of an error.</param>
        ///// <param name="args">The arguments to format the message with.</param>
        ///// <returns>A new instance of <seealso cref="Task"/> that will perform the
        ///// code specified in <paramref name="function"/>.</returns>
        //protected Task<ActionResult> DoTask(Func<HttpContextBase, ActionResult> function, string errorMessage = "Error default", params object[] args)
        //{
        //    return Task.Factory.StartNew(context =>
        //    {
        //        try
        //        {
        //            return function((HttpContextBase)context);
        //        }
        //        catch (Exception ex)
        //        {
        //            // log and return an error response rather than hitting the application's
        //            // error handler - we've dealt with it here.
        //            //_logger.Error(ex, errorMessage, args);
        //            return new HttpStatusCodeResult(500 /*server error*/);
        //        }
        //    }, HttpContext);
        //}

        // GET: InputFileHandler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InputFileHandler/Create
        public ActionResult Create()
        {
            var fileReaderService = new FileReaderService();
            fileReaderService.PopulateCSVToEntity();
            return View();
        }

        // POST: InputFileHandler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InputFileHandler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InputFileHandler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InputFileHandler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InputFileHandler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
