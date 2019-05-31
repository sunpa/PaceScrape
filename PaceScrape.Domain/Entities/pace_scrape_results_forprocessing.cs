using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PaceScrape.Domain.Entities
{
    public class pace_scrape_results_forprocessing
    {
        [Key]
        public decimal Id { get; set; }

        public string AccountNo { get; set; }

        public string Apn { get; set; }

        public string County { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? RequestedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? ProcessedDate { get; set; }

        public string ScrapingStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? PaymentDueDate { get; set; }

        public string PaymentStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? PaidDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? AmountPaid { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? PaymentProcessDate { get; set; }

        [DisplayFormat(NullDisplayText = "")]
        public string PaymentProcessStatus { get; set; }

        public bool CheckStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0}")]
        public decimal PaymentNo { get; set; }

        [DisplayFormat(DataFormatString = "{0}")]
        public decimal InstallmentNo { get; set; }

        public string Source { get; set; }

        public List<SelectListItem> getCountyList()
        {
            List<SelectListItem> countyList = new List<SelectListItem>();

            countyList.Add(new SelectListItem { Value = "", Text = "Select a County" });
            countyList.Add(new SelectListItem { Value = "Alameda", Text = "Alameda" });
            countyList.Add(new SelectListItem { Value = "Contra Costa", Text = "Contra Costa" });
            countyList.Add(new SelectListItem { Value = "Fresno", Text = "Fresno" });
            countyList.Add(new SelectListItem { Value = "Kern", Text = "Kern" });
            countyList.Add(new SelectListItem { Value = "Kings", Text = "Kings" });
            countyList.Add(new SelectListItem { Value = "Los Angeles", Text = "Los Angeles" });
            countyList.Add(new SelectListItem { Value = "Orange", Text = "Orange" });
            countyList.Add(new SelectListItem { Value = "Riverside", Text = "Riverside" });
            countyList.Add(new SelectListItem { Value = "Sacramento", Text = "Sacramento" });
            countyList.Add(new SelectListItem { Value = "San Bernardino", Text = "San Bernardino" });
            countyList.Add(new SelectListItem { Value = "San Diego", Text = "San Diego" });
            countyList.Add(new SelectListItem { Value = "San Francisco", Text = "San Francisco" });
            countyList.Add(new SelectListItem { Value = "San Joaquin", Text = "San Joaquin" });
            countyList.Add(new SelectListItem { Value = "San Luis Obispo", Text = "San Luis Obispo" });
            countyList.Add(new SelectListItem { Value = "San Mateo", Text = "San Mateo" });
            countyList.Add(new SelectListItem { Value = "Santa Clara", Text = "Santa Clara" });
            countyList.Add(new SelectListItem { Value = "Santa Cruz", Text = "Santa Cruz" });
            countyList.Add(new SelectListItem { Value = "Solano", Text = "Solano" });
            countyList.Add(new SelectListItem { Value = "Sonoma", Text = "Sonoma" });
            countyList.Add(new SelectListItem { Value = "Stanislaus", Text = "Stanislaus" });
            countyList.Add(new SelectListItem { Value = "Sutter", Text = "Sutter" });
            countyList.Add(new SelectListItem { Value = "Tulare", Text = "Tulare" });
            countyList.Add(new SelectListItem { Value = "Ventura", Text = "Ventura" });
            countyList.Add(new SelectListItem { Value = "Yuba", Text = "Yuba" });

            return countyList.ToList();
        }

    }
}
