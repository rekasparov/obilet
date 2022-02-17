using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.DTOs
{
    public class Stop
    {
        public string name { get; set; }

        [JsonProperty("is-origin")]
        public bool isOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool isDestination { get; set; }
    }
}
