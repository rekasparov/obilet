using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Concretes
{
    public class SessionRequestModel : IDisposable
    {
        public int Type { get => 1; }
        public ConnectionModel Connection { get => new ConnectionModel(); }
        public BrowserModel Browser { get => new BrowserModel(); }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public class ConnectionModel
        {
            [JsonProperty("ip-address")]
            public string IpAddress { get => "165.114.41.21"; }

            public string Port { get => "5117"; }
        }

        public class BrowserModel
        {
            public string Name { get => "Chrome"; }

            public string Version { get => "47.0.0.12"; }
        }
    }
}
