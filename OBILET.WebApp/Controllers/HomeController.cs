using Microsoft.AspNetCore.Mvc;
using OBILET.WebApp.Helpers.Models.Concretes;
using OBILET.WebApp.Helpers.Abstracts;
using OBILET.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OBILET.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiHelper apiHelper;

        public HomeController(IApiHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public async Task<IActionResult> Index(int originId, int destinationId, string departureDateStr)
        {
            if (parametersIsValid(originId, destinationId, departureDateStr))
                return View(await getBusJourneys(originId, destinationId, departureDateStr));
            else
                return RedirectToAction("Index", "Landing");
        }

        private bool parametersIsValid(int originId, int destinationId, string departureDateStr)
        {
            if (originId < 1 || destinationId < 1 || string.IsNullOrEmpty(departureDateStr))
                return false;

            return true;
        }

        private async Task<JourneyResultModel> getBusJourneys(int originId, int destinationId, string departureDateStr)
        {
            try
            {
                DateTime departureDate = DateTime.Parse(departureDateStr);

                List<BusJourneyResponseModel.DataModel> journeies = await apiHelper.GetBusJourneys(originId, destinationId, departureDate);

                return new JourneyResultModel()
                {
                    DepartureDate = departureDate,
                    OriginLocation = journeies.FirstOrDefault().OriginLocation,
                    DestinationLocation = journeies.FirstOrDefault().DestinationLocation,
                    Journeies = journeies
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
