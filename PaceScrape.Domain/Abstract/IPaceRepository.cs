using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaceScrape.Domain.Entities;

namespace PaceScrape.Domain.Abstract
{
    public interface IPaceRepository
    {
        IQueryable<pace_scrape_results_forpayments> ScrapeResultsForPayments { get; }

        IQueryable<pace_scrape_results_forpayments> GetScrapeResults(DateTime scrapeProcessedDate, string county, string status);

        IQueryable<pace_scrape_results_forpayments> SearchAccountNo(DateTime scrapeProcessedDate, string accountNo);

        IQueryable<pace_scrape_results_forpayments> GetAccount(int id);

        void UpdateScrapeResult(pace_scrape_results_forpayments scrapeResult);

        void AddScrapeChangeLog(pace_scrape_results_forpayments dbEntry, pace_scrape_results_forpayments scrapeResult);

        IQueryable<pace_scrape_results_forpayments> ScrapeProcessedDates { get; }

        IQueryable<ScrapeEdit> GetScrapeEdit(int id);

    }
}
