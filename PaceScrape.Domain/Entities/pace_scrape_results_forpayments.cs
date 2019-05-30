using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PaceScrape.Domain.Entities
{
    public class pace_scrape_results_forpayments
    {
        [Key]
        public decimal Id { get; set; }

        public string AccountNo { get; set; }

        public string Apn { get; set; }

        public string County { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? RequestedDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? ProessedDate { get; set; }

        public string Status { get; set; }

        public string DueDate1 { get; set; }

        public string DueDate2 { get; set; }

        public string PaymentStatus1 { get; set; }

        public string PaymentStatus2 { get; set; }

        public string PaidDate1 { get; set; }

        public string PaidDate2 { get; set; }

        public decimal? AmountPaid1 { get; set; }

        public decimal? AmountPaid2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/dd/yyyy}")]
        public DateTime? PaymentProcessDate { get; set; }

        [DisplayFormat(NullDisplayText = "")]
        public string PaymentProcessStatus { get; set; }

        public string Comments { get; set; }

        public bool CheckStatus1 { get; set; }

        public bool CheckStatus2 { get; set; }


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
