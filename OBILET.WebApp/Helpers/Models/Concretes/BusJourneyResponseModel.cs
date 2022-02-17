using Newtonsoft.Json;
using OBILET.WebApp.Helpers.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Concretes
{
    public class BusJourneyResponseModel : IBaseResponseModel
    {
        public BusJourneyResponseModel()
        {
            Data = new List<DataModel>();
        }

        public string Status { get; set; }

        public List<DataModel> Data { get; set; }

        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }

        public string Controller { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public class DataModel
        {
            public int Id { get; set; }

            [JsonProperty("origin-location")]
            public string OriginLocation { get; set; }

            [JsonProperty("destination-location")]
            public string DestinationLocation { get; set; }

            public JourneyModel Journey { get; set; }


            public class JourneyModel
            {
                public DateTime Departure { get; set; }

                public DateTime Arrival { get; set; }

                [JsonProperty("original-price")]
                public decimal OriginalPrice { get; set; }

                public List<StopModel> Stops { get; set; }


                public class StopModel
                {
                    public string name { get; set; }

                    [JsonProperty("is-origin")]
                    public bool isOrigin { get; set; }

                    [JsonProperty("is-destination")]
                    public bool isDestination { get; set; }
                }
            }
        }
    }
}
