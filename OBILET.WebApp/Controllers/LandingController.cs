using Microsoft.AspNetCore.Mvc;
using OBILET.WebApp.Helpers.Abstracts;
using OBILET.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static OBILET.WebApp.Helpers.Models.Concretes.BusLocationResponseModel;

namespace OBILET.WebApp.Controllers
{
    public class LandingController : Controller
    {
        private readonly IApiHelper apiHelper;

        public LandingController(IApiHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<SearchResultModel> GetSearchResults([FromQuery] string q)
        {
            return await getBusLocation(q);
        }

        private async Task<SearchResultModel> getBusLocation(string keyword)
        {
            List<DataModel> items = await apiHelper.GetBusLocation(keyword);

            return new SearchResultModel()
            {
                items = items,
                total_count = items.Count
            };
        }
    }
}
