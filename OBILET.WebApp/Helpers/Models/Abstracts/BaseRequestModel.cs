using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Abstracts
{
    public abstract class BaseRequestModel : IDisposable
    {
        [JsonProperty("device-session")]
        public DeviceSessionModel DeviceSession { get; set; }

        public string Date { get; set; }

        public string Language { get => "tr-TR"; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public class DeviceSessionModel
        {
            [JsonProperty("session-id")]
            public string SessionId { get; set; }

            [JsonProperty("device-id")]
            public string DeviceId { get; set; }
        }
    }
}
