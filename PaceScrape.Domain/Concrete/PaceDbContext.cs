using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaceScrape.Domain.Entities;

namespace PaceScrape.Domain.Concrete
{
    public class PaceDbContext : DbContext
    {
        public PaceDbContext() : base("PaceDbContext")
        { }

        public DbSet<pace_scrape_results_forpayments> ScrapeResultsForPayments { get; set; }

        public DbSet<pace_county_details> CountyDetails { get; set; }

        public DbSet<pace_scrape_change_log> ScrapeChangeLog { get; set; }
    }
}
