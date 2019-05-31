using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaceScrape.Domain.Abstract;
using PaceScrape.Domain.Entities;
using PaceScrape.Domain.Concrete;

namespace PaceScrape.Controllers
{
    public class HomeController : Controller
    {
        private IPaceRepository paceRepository;

        public HomeController() { }


        public HomeController(IPaceRepository pacerepo)
        {
            paceRepository = pacerepo;
        }


        public ActionResult Index()
        {
            List<SelectListItem> scrapeProcessedDates = new List<SelectListItem>();

            var result = paceRepository.ScrapeProcessedDates;
            string temp = "";

            foreach (var item in result)
            {
                if (temp != item.ProcessedDate.Value.ToShortDateString())
                {
                    scrapeProcessedDates.Add(new SelectListItem
                    {
                        Text = item.ProcessedDate.Value.ToShortDateString(),
                        Value = item.ProcessedDate.Value.ToShortDateString()
                    });
                    temp = item.ProcessedDate.Value.ToShortDateString();
                }
            }
            this.ViewData["ScrapeProcessedDates"] = scrapeProcessedDates;

            pace_scrape_results_forprocessing objModel = new pace_scrape_results_forprocessing();
            this.ViewData["Counties"] = objModel.getCountyList();

            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add(new SelectListItem { Text = "SUCCESS", Value = "SUCCESS" });
            Status.Add(new SelectListItem { Text = "FAILED", Value = "FAILED" });
            this.ViewData["Status"] = Status;

            return View();
        }


        [HttpPost]
        public ActionResult Results()
        {
            DateTime scrapeProcessedDate = Convert.ToDateTime(Request["ScrapeProcessedDates"]);
            string county = Request["Counties"];
            string status = Request["Status"];
            string accountNo = Request["AccountNo"];

            ViewData["scrapeProcessedDate"] = scrapeProcessedDate;
            ViewData["county"] = county;
            ViewData["status"] = status;
            ViewData["accountno"] = accountNo;

            if (string.IsNullOrEmpty(accountNo))
            {
                return View(paceRepository.GetScrapeResults(scrapeProcessedDate, county, status).ToList());
            }
            else
            {
                return View(paceRepository.SearchAccountNo(scrapeProcessedDate, accountNo).ToList());
            }
        }

        public ActionResult Edit(int id)
        {
            TempData["ID"] = id;

            return View(paceRepository.GetScrapeEdit(id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(pace_scrape_results_forprocessing scrapeResult)
        {
            int id = Convert.ToInt32(TempData["ID"]);
            try
            {
                paceRepository.UpdateScrapeResult(scrapeResult);
                this.ViewData["UpdateSubmit"] = "Updated successfully";
                TempData["ID"] = id;
            }
            catch (Exception ex)
            { this.ViewData["UpdateSubmit"] = ex.ToString(); }

            return View(paceRepository.GetScrapeEdit(id).FirstOrDefault());
            //return RedirectToAction("Results", "Home", new { ProessedDate = scrapeResult.ProessedDate, County = scrapeResult.County, Status = scrapeResult.Status });          
        }
    }
}