using OBILET.WebApp.Helpers.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Models
{
    public class JourneyResultModel
    {
        public JourneyResultModel()
        {
            Journeies = new List<BusJourneyResponseModel.DataModel>();
        }

        public DateTime DepartureDate { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public List<BusJourneyResponseModel.DataModel> Journeies { get; set; }
    }
}
