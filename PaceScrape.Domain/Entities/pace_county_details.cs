using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceScrape.Domain.Entities
{
    public class pace_county_details
    {
        [Key]
        public decimal id { get; set; }

        public string name { get; set; }

        public string state_code { get; set; }

        public string countyurl { get; set; }
    }
}
