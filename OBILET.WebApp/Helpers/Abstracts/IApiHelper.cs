using OBILET.WebApp.Helpers.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Abstracts
{
    public interface IApiHelper : IDisposable
    {
        public Task<List<BusLocationResponseModel.DataModel>> GetBusLocation(string keyword);
        public Task<List<BusJourneyResponseModel.DataModel>> GetBusJourneys(int originId, int destinationId, DateTime departureDate);
    }
}
