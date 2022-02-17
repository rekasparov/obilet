using Newtonsoft.Json;
using OBILET.WebApp.Helpers.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Concretes
{
    public class SessionResponseModel : IBaseResponseModel
    {
        public string Status { get; set; }

        public DataModel Data { get; set; }

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
            [JsonProperty("session-id")]
            public string SessionId { get; set; }

            [JsonProperty("device-id")]
            public string DeviceId { get; set; }
        }
    }
}
