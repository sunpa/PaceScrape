using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceScrape.Domain.Entities
{
    public class pace_scrape_change_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public string PaymentStatusbefore { get; set; }

        public string PaymentStatusafter { get; set; }
        
        public DateTime? PaidDatebefore { get; set; }

        public DateTime? PaidDateafter { get; set; }

        public decimal? AmountPaidbefore { get; set; }

        public decimal? AmountPaidafter { get; set; }

        public string AccountNo { get; set; }

        public string Apn { get; set; }

        public string County { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public string ScrapingStatus { get; set; }

        public string Userid { get; set; }

        public decimal PaymentNo { get; set; }

        public decimal InstallmentNo { get; set; }

        public bool PaymentStatusChanged { get; set; }

        public bool PaidDateChanged { get; set; }

        public bool AmountPaidChanged { get; set; }
    }
}
