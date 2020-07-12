using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketRatesEvaluation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketRatesEvaluation.Controllers
{
    public class InputFileHandler : Controller
    {
        // GET: InputFileHandler
        public ActionResult Index()
        {
            var fileReaderService = new FileReaderService();
            fileReaderService.PopulateCSVToEntity();
            return View();
        }

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
