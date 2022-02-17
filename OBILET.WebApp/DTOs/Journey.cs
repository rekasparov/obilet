using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.DTOs
{
    public class Journey
    {
        public DateTime departure { get; set; }

        public DateTime arrival { get; set; }

        [JsonProperty("original-price")]
        public decimal originalPrice { get; set; }

        public List<Stop> Stops { get; set; }
    }
}
