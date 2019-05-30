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

        public string PaymentStatus1before { get; set; }

        public string PaymentStatus2before { get; set; }

        public string PaymentStatus1after { get; set; }

        public string PaymentStatus2after { get; set; }
        
        public string PaidDate1before { get; set; }

        public string PaidDate2before { get; set; }

        public string PaidDate1after { get; set; }

        public string PaidDate2after { get; set; }

        public decimal? AmountPaid1before { get; set; }

        public decimal? AmountPaid2before { get; set; }

        public decimal? AmountPaid1after { get; set; }

        public decimal? AmountPaid2after { get; set; }

        public string AccountNo { get; set; }

        public string Apn { get; set; }

        public string County { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public string Status { get; set; }

        public string Userid { get; set; }

        public bool PaymentStatus1Changed { get; set; }

        public bool PaymentStatus2Changed { get; set; }

        public bool PaidDate1Changed { get; set; }

        public bool PaidDate2Changed { get; set; }

        public bool AmountPaid1Changed { get; set; }

        public bool AmountPaid2Changed { get; set; }
    }
}
