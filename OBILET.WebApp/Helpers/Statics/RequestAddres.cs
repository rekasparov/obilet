using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Statics
{
    public static class RequestAddres
    {
        public static string GetSession { get => "https://v2-api.obilet.com/api/client/getsession"; }
        public static string GetBusLocations { get => "https://v2-api.obilet.com/api/location/getbuslocations"; }
        public static string GetBusJourneys { get => "https://v2-api.obilet.com/api/journey/getbusjourneys"; }
    }
}
