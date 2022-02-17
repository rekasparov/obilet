using Newtonsoft.Json;
using OBILET.WebApp.Helpers.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Concretes
{
    public class BusJourneyRequestModel : BaseRequestModel
    {
        public DataModel Data { get; set; }

        public class DataModel
        {
            [JsonProperty("origin-id")]
            public int OriginId { get; set; }

            [JsonProperty("destination-id")]
            public int DestinationId { get; set; }

            [JsonProperty("departure-date")]
            public string DepartureDate { get; set; }
        }
    }
}
