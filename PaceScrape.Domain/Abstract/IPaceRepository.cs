﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaceScrape.Domain.Entities;

namespace PaceScrape.Domain.Abstract
{
    public interface IPaceRepository
    {
        IQueryable<pace_scrape_results_forprocessing> ScrapeResultsForPayments { get; }

        IQueryable<pace_scrape_results_forprocessing> GetScrapeResults(DateTime scrapeProcessedDate, string county, string status);

        IQueryable<pace_scrape_results_forprocessing> SearchAccountNo(DateTime scrapeProcessedDate, string accountNo);

        IQueryable<pace_scrape_results_forprocessing> GetAccount(int id);

        void UpdateScrapeResult(pace_scrape_results_forprocessing scrapeResult);

        void AddScrapeChangeLog(pace_scrape_results_forprocessing dbEntry, pace_scrape_results_forprocessing scrapeResult);

        //IQueryable<pace_scrape_results_forpayments> ScrapeProcessedDates { get; }
        IQueryable<pace_scrape_results_forprocessing> ScrapeProcessedDates { get; }

        IQueryable<ScrapeEdit> GetScrapeEdit(int id);

    }
}
