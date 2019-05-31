using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaceScrape.Domain.Abstract;
using PaceScrape.Domain.Entities;

namespace PaceScrape.Domain.Concrete
{
    public class PaceRepository : IPaceRepository
    {
        private PaceDbContext context = new PaceDbContext();

        public IQueryable<pace_scrape_results_forprocessing> ScrapeProcessedDates
        {
            get
            {
                var results = (from r in context.ScrapeResultsForProcessing
                               where r.ProcessedDate.Value.Year >= 2019
                               orderby r.ProcessedDate descending
                               select r);

                return results;
            }
        }

        public IQueryable<pace_scrape_results_forprocessing> GetScrapeResults(DateTime scrapeProcessedDate, string county, string status)
        {
            //var processedDateParameter = new SqlParameter("@ProcessDate", scrapeProcessedDate);

            //var result = context.Database.SqlQuery("exec pace_sp_get_scrapepayments @ProcessDate ", scrapeProcessedDate.ToShortDateString()).ToList <pace_scrape_results_forpayments> ();

            //return result.AsQueryable();


            // marked out for testing
            if (county == "")
            {
                var recall = (context.ScrapeResultsForProcessing
                    .Where(r => r.ScrapingStatus == status)
                    .Where(r => r.ProcessedDate == scrapeProcessedDate)
                    //.Where(r => r.County == county)
                    .OrderBy(r => r.County).AsQueryable());

                return recall;
            }
            else
            {
                var rec = (context.ScrapeResultsForProcessing
                    .Where(r => r.ScrapingStatus == status)
                    .Where(r => r.ProcessedDate == scrapeProcessedDate)
                    .Where(r => r.County == county)
                    .OrderBy(r => r.County).AsQueryable());

                return rec;
            }
        }

        public IQueryable<pace_scrape_results_forprocessing> GetAccount(int id)
        {
            var record = (from r in context.ScrapeResultsForProcessing
                          where r.Id == id
                          select r);
            return record;
        }

        public IQueryable<pace_scrape_results_forprocessing> SearchAccountNo(DateTime scrapeProcessedDate, string accountNo)
        {

            return (context.ScrapeResultsForProcessing
                .Where(r => r.RequestedDate == scrapeProcessedDate)
                .Where(r => r.AccountNo == accountNo));
        }

        public IQueryable<pace_scrape_results_forprocessing> ScrapeResultsForPayments
        {
            get
            {

                var test = (from r in context.ScrapeResultsForProcessing
                            where r.County == "Ventura"
                            && r.ScrapingStatus == "SUCCESS"
                            select r);

                return test;
            }
        }

        public IQueryable<ScrapeEdit> GetScrapeEdit(int id)
        {
            var accounts = (from sr in context.ScrapeResultsForProcessing
                            join cd in context.CountyDetails on sr.County equals cd.name
                            where sr.Id == id
                            select new ScrapeEdit
                            {
                                accountno = sr.AccountNo,
                                apn = sr.Apn,
                                county = sr.County,
                                requesteddate = sr.RequestedDate,
                                processeddate = sr.ProcessedDate,
                                scrapingstatus = sr.ScrapingStatus,
                                countyurl = cd.countyurl,
                                paymentno = sr.PaymentNo,
                                installmentno = sr.InstallmentNo,                                
                                paymentduedate = sr.PaymentDueDate,
                                paymentstatus = sr.PaymentStatus,                                
                                paiddate = sr.PaidDate,                                
                                amountpaid = sr.AmountPaid,
                                paymentprocessdate = sr.PaymentProcessDate,
                                paymentprocessstatus = sr.PaymentProcessStatus
                            }).AsQueryable();

            return accounts;
        }


        public void UpdateScrapeResult(pace_scrape_results_forprocessing scrapeResult)
        {
            pace_scrape_results_forpayments dbEntry = context.ScrapeResultsForPayments.Find(scrapeResult.Id);

            //log it first
            //AddScrapeChangeLog(dbEntry, scrapeResult);

            //dbEntry.PaymentStatus1 = scrapeResult.PaymentStatus1;
            //dbEntry.PaymentStatus2 = scrapeResult.PaymentStatus2;
            //dbEntry.PaidDate1 = scrapeResult.PaidDate1;
            //dbEntry.PaidDate2 = scrapeResult.PaidDate2;
            //dbEntry.AmountPaid1 = scrapeResult.AmountPaid1;
            //dbEntry.AmountPaid2 = scrapeResult.AmountPaid2;

            context.SaveChanges();
        }

        public void AddScrapeChangeLog(pace_scrape_results_forprocessing dbEntry, pace_scrape_results_forprocessing scrapeResult)
        {
            try
            {
                string userid = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last();

                pace_scrape_change_log dbLog = new pace_scrape_change_log();

                dbLog.AccountNo = dbEntry.AccountNo;
                dbLog.Apn = dbEntry.Apn;
                dbLog.County = dbEntry.County;
                //dbLog.ProcessedDate = dbEntry.ProessedDate;
                //dbLog.Status = dbEntry.Status;
                //dbLog.PaymentStatus1before = dbEntry.PaymentStatus1;
                //dbLog.PaymentStatus1after = scrapeResult.PaymentStatus1;
                //dbLog.PaymentStatus2before = dbEntry.PaymentStatus2;
                //dbLog.PaymentStatus2after = scrapeResult.PaymentStatus2;
                //dbLog.PaidDate1before = dbEntry.PaidDate1;
                //dbLog.PaidDate1after = scrapeResult.PaidDate1;
                //dbLog.PaidDate2before = dbEntry.PaidDate2;
                //dbLog.PaidDate2after = scrapeResult.PaidDate2;
                //dbLog.AmountPaid1before = dbEntry.AmountPaid1;
                //dbLog.AmountPaid1after = scrapeResult.AmountPaid1;
                //dbLog.AmountPaid2before = dbEntry.AmountPaid2;
                //dbLog.AmountPaid2after = scrapeResult.AmountPaid2;
                dbLog.Userid = userid;
                if (dbLog.PaymentStatus1before != dbLog.PaymentStatus1after)
                {
                    dbLog.PaymentStatus1Changed = true;
                }
                if (dbLog.PaymentStatus2before != dbLog.PaymentStatus2after)
                {
                    dbLog.PaymentStatus2Changed = true;
                }
                if (dbLog.PaidDate1before != dbLog.PaidDate1after)
                {
                    dbLog.PaidDate1Changed = true;
                }
                if (dbLog.PaidDate2before != dbLog.PaidDate2after)
                {
                    dbLog.PaidDate2Changed = true;
                }
                if (dbLog.AmountPaid1before != dbLog.AmountPaid1after)
                {
                    dbLog.AmountPaid1Changed = true;
                }
                if (dbLog.AmountPaid2before != dbLog.AmountPaid2after)
                {
                    dbLog.AmountPaid2Changed = true;
                }

                context.ScrapeChangeLog.Add(dbLog);
            }
            catch (Exception ex)
            { }
        }


















        //DEPRECATED

        //public IQueryable<pace_scrape_results_forpayments> GetAccount(int id)
        //{
        //    var record = (from r in context.ScrapeResultsForPayments
        //                  where r.Id == id
        //                  select r);
        //    return record;
        //}


        //public IQueryable<pace_scrape_results_forpayments> SearchAccountNo(DateTime scrapeProcessedDate, string accountNo)
        //{

        //    return (context.ScrapeResultsForPayments
        //        .Where(r => r.RequestedDate == scrapeProcessedDate)
        //        .Where(r => r.AccountNo == accountNo));
        //}

        //public IQueryable<pace_scrape_results_forpayments> ScrapeProcessedDates
        //{
        //    get
        //    {
        //        var results = (from r in context.ScrapeResultsForPayments
        //                       where r.ProessedDate.Value.Year >= 2019
        //                       orderby r.ProessedDate descending
        //                       select r);

        //        return results;
        //    }
        //}


        //public IQueryable<pace_scrape_results_forpayments> ScrapeResultsForPayments
        //{
        //    get
        //    {

        //        var test = (from r in context.ScrapeResultsForPayments
        //                    where r.County == "Ventura"
        //                    && r.Status == "SUCCESS"
        //                    select r);

        //        return test;
        //    }
        //}

        //public IQueryable<pace_scrape_results_forpayments> GetScrapeResults(DateTime scrapeProcessedDate, string county, string status)
        //{
        //    string paidDate1 = "";
        //    string paidDate2 = "";

        //    //var processedDateParameter = new SqlParameter("@ProcessDate", scrapeProcessedDate);

        //    //var result = context.Database.SqlQuery("exec pace_sp_get_scrapepayments @ProcessDate ", scrapeProcessedDate.ToShortDateString()).ToList <pace_scrape_results_forpayments> ();

        //    //return result.AsQueryable();


        //    // marked out for testing
        //    if (county == "")
        //    {
        //        var recall = (context.ScrapeResultsForPayments
        //            .Where(r => r.Status == status)
        //            .Where(r => r.ProessedDate == scrapeProcessedDate)
        //            //.Where(r => r.County == county)
        //            .OrderBy(r => r.County).AsQueryable());

        //        return recall;
        //    }
        //    else
        //    {
        //        var rec = (context.ScrapeResultsForPayments
        //            .Where(r => r.Status == status)
        //            .Where(r => r.ProessedDate == scrapeProcessedDate)
        //            .Where(r => r.County == county)
        //            .OrderBy(r => r.County).AsQueryable());

        //        return rec;
        //    }
        //}

        //public IQueryable<ScrapeEdit> GetScrapeEdit(int id)
        //{
        //    var accounts = (from sr in context.ScrapeResultsForPayments
        //                    join cd in context.CountyDetails on sr.County equals cd.name
        //                    where sr.Id == id
        //                    select new ScrapeEdit
        //                    {
        //                        accountno = sr.AccountNo,                                
        //                        apn = sr.Apn,
        //                        status = sr.Status,
        //                        county = sr.County,
        //                        countyurl = cd.countyurl,
        //                        requesteddate = sr.RequestedDate,
        //                        proesseddate = sr.ProessedDate,
        //                        duedate1 = sr.DueDate1,
        //                        duedate2 = sr.DueDate2,
        //                        paymentstatus1 = sr.PaymentStatus1,
        //                        paymentstatus2 = sr.PaymentStatus2,
        //                        paiddate1 = sr.PaidDate1,
        //                        paiddate2 = sr.PaidDate2,
        //                        amountpaid1 = sr.AmountPaid1,
        //                        amountpaid2 = sr.AmountPaid2
        //                    }).AsQueryable();

        //    return accounts;
        //}

        //public void UpdateScrapeResult(pace_scrape_results_forpayments scrapeResult)
        //{
        //    pace_scrape_results_forpayments dbEntry = context.ScrapeResultsForPayments.Find(scrapeResult.Id);

        //    //log it first
        //    AddScrapeChangeLog(dbEntry, scrapeResult);

        //    dbEntry.PaymentStatus1 = scrapeResult.PaymentStatus1;
        //    dbEntry.PaymentStatus2 = scrapeResult.PaymentStatus2;
        //    dbEntry.PaidDate1 = scrapeResult.PaidDate1;
        //    dbEntry.PaidDate2 = scrapeResult.PaidDate2;
        //    dbEntry.AmountPaid1 = scrapeResult.AmountPaid1;
        //    dbEntry.AmountPaid2 = scrapeResult.AmountPaid2;

        //    context.SaveChanges();
        //}

        //public void AddScrapeChangeLog(pace_scrape_results_forpayments dbEntry, pace_scrape_results_forpayments scrapeResult)
        //{
        //    try
        //    {
        //        string userid = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last();

        //        pace_scrape_change_log dbLog = new pace_scrape_change_log();

        //        dbLog.AccountNo = dbEntry.AccountNo;
        //        dbLog.Apn = dbEntry.Apn;
        //        dbLog.County = dbEntry.County;
        //        dbLog.ProcessedDate = dbEntry.ProessedDate;
        //        dbLog.Status = dbEntry.Status;
        //        dbLog.PaymentStatus1before = dbEntry.PaymentStatus1;
        //        dbLog.PaymentStatus1after = scrapeResult.PaymentStatus1;
        //        dbLog.PaymentStatus2before = dbEntry.PaymentStatus2;
        //        dbLog.PaymentStatus2after = scrapeResult.PaymentStatus2;
        //        dbLog.PaidDate1before = dbEntry.PaidDate1;
        //        dbLog.PaidDate1after = scrapeResult.PaidDate1;
        //        dbLog.PaidDate2before = dbEntry.PaidDate2;
        //        dbLog.PaidDate2after = scrapeResult.PaidDate2;
        //        dbLog.AmountPaid1before = dbEntry.AmountPaid1;
        //        dbLog.AmountPaid1after = scrapeResult.AmountPaid1;
        //        dbLog.AmountPaid2before = dbEntry.AmountPaid2;
        //        dbLog.AmountPaid2after = scrapeResult.AmountPaid2;
        //        dbLog.Userid = userid;
        //        if(dbLog.PaymentStatus1before != dbLog.PaymentStatus1after)
        //        {
        //            dbLog.PaymentStatus1Changed = true;
        //        }
        //        if (dbLog.PaymentStatus2before != dbLog.PaymentStatus2after)
        //        {
        //            dbLog.PaymentStatus2Changed = true;
        //        }
        //        if (dbLog.PaidDate1before != dbLog.PaidDate1after)
        //        {
        //            dbLog.PaidDate1Changed = true;
        //        }
        //        if (dbLog.PaidDate2before != dbLog.PaidDate2after)
        //        {
        //            dbLog.PaidDate2Changed = true;
        //        }
        //        if (dbLog.AmountPaid1before != dbLog.AmountPaid1after)
        //        {
        //            dbLog.AmountPaid1Changed = true;
        //        }
        //        if (dbLog.AmountPaid2before != dbLog.AmountPaid2after)
        //        {
        //            dbLog.AmountPaid2Changed = true;
        //        }

        //        context.ScrapeChangeLog.Add(dbLog);
        //    }
        //    catch (Exception ex)
        //    { }
        //}
    }
}
