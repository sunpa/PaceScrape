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
        public string paymentprocessstatus { get; set; }

        public string accountno { get; set; }

        public string apn { get; set; }

        public string scrapingstatus { get; set; }

        public string county { get; set; }

        public string countyurl { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? requesteddate { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? processeddate { get; set; }

        [DisplayFormat(DataFormatString = "{0}")]
        public decimal paymentno { get; set; }

        [DisplayFormat(DataFormatString = "{0}")]
        public decimal installmentno { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? paymentduedate { get; set; }

        public string paymentstatus { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? paiddate { get; set; }

        public decimal? amountpaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? paymentprocessdate { get; set; }

    }
}
