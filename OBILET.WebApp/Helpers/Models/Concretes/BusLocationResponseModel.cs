using Newtonsoft.Json;
using OBILET.WebApp.Helpers.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Concretes
{
    public class BusLocationResponseModel : IBaseResponseModel
    {
        public BusLocationResponseModel()
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

            [JsonProperty("parent-id")]
            public int? ParentId { get; set; }

            public string Type { get; set; }

            public string Name { get; set; }

            [JsonProperty("geo-location")]
            public GeoLocationModel GeoLocation { get; set; }

            [JsonProperty("tz-code")]
            public string TzCode { get; set; }

            [JsonProperty("weather-code")]
            public string WeatherCode { get; set; }

            public int? Rank { get; set; }

            public string Keywords { get; set; }

            [JsonProperty("reference-code")]
            public string ReferenceCode { get; set; }


            public class GeoLocationModel
            {
                public decimal Latitude { get; set; }
                public decimal Longitude { get; set; }
                public int Zoom { get; set; }
            }
        }
    }
}
