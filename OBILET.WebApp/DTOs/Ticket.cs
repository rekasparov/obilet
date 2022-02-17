using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.DTOs
{
    public class Ticket
    {
        public int id { get; set; }

        [JsonProperty("origin-location")]
        public string originLocation { get; set; }

        [JsonProperty("destination-location")]
        public string destinationLocation { get; set; }

        public Journey Journey { get; set; }
    }
}
