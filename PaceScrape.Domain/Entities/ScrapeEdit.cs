using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceScrape.Domain.Entities
{
    public class ScrapeEdit
    {
        public string accountno { get; set; }

        public string apn { get; set; }

        public string status { get; set; }

        public string county { get; set; }

        public string countyurl { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? requesteddate { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? proesseddate { get; set; }

        public string duedate1 { get; set; }

        public string duedate2 { get; set; }

        public string paymentstatus1 { get; set; }

        public string paymentstatus2 { get; set; }

        public string paiddate1 { get; set; }

        public string paiddate2 { get; set; }

        public decimal? amountpaid1 { get; set; }

        public decimal? amountpaid2 { get; set; }



    }
}
