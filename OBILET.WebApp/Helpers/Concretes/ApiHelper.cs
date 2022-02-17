using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OBILET.WebApp.Helpers.Models.Concretes;
using OBILET.WebApp.Helpers.Abstracts;
using OBILET.WebApp.Helpers.Statics;
using OBILET.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static OBILET.WebApp.Helpers.Models.Concretes.BusLocationResponseModel;
using static OBILET.WebApp.Helpers.Models.Abstracts.BaseRequestModel;
using Microsoft.AspNetCore.Http;

namespace OBILET.WebApp.Helpers.Concretes
{
    public class ApiHelper : IApiHelper
    {
        private SessionResponseModel sessionResponseModel { get; }

        private readonly IConfiguration configuration;

        public ApiHelper(IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            this.configuration = configuration;

            string jsonSessionResponseModel = httpContext.HttpContext.Session.GetString("user");

            if (jsonSessionResponseModel == null)
            {
                sessionResponseModel = getSession().Result;

                jsonSessionResponseModel = JsonConvert.SerializeObject(sessionResponseModel);

                httpContext.HttpContext.Session.SetString("user", jsonSessionResponseModel);
            }
            else
                sessionResponseModel = JsonConvert.DeserializeObject<SessionResponseModel>(jsonSessionResponseModel);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<BusJourneyResponseModel.DataModel>> GetBusJourneys(int originId, int destinationId, DateTime departureDate)
        {
            try
            {
                using BusJourneyRequestModel busJourneyRequestModel = new BusJourneyRequestModel()
                {
                    DeviceSession = new DeviceSessionModel()
                    {
                        SessionId = sessionResponseModel.Data.SessionId,
                        DeviceId = sessionResponseModel.Data.DeviceId
                    },
                    Data = new BusJourneyRequestModel.DataModel()
                    {
                        OriginId = originId,
                        DestinationId = destinationId,
                        DepartureDate = departureDate.ToString("yyyy-MM-dd")
                    },
                    Date = DateTime.Now.ToString("yyyy-MM-dd")
                };

                using HttpClient httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient.DefaultRequestHeaders.Add("Authorization", configuration.GetSection("Authorization").Value);

                using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(RequestAddres.GetBusJourneys));

                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(busJourneyRequestModel), Encoding.UTF8, "application/json");

                using HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string jsonBusJourneyResponseModel = await httpResponseMessage.Content.ReadAsStringAsync();

                BusJourneyResponseModel busJourneyResponseModel = JsonConvert.DeserializeObject<BusJourneyResponseModel>(jsonBusJourneyResponseModel);

                if (busJourneyResponseModel.Status != "Success") throw new HttpRequestException(busJourneyResponseModel.Message);

                return busJourneyResponseModel.Data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DataModel>> GetBusLocation(string keyword)
        {
            try
            {
                using BusLocationRequestModel busLocationRequestModel = new BusLocationRequestModel()
                {
                    Data = keyword,
                    DeviceSession = new DeviceSessionModel()
                    {
                        SessionId = sessionResponseModel.Data.SessionId,
                        DeviceId = sessionResponseModel.Data.DeviceId
                    },
                    Date = DateTime.Now.ToString()
                };

                using HttpClient httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient.DefaultRequestHeaders.Add("Authorization", configuration.GetSection("Authorization").Value);

                using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(RequestAddres.GetBusLocations));

                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(busLocationRequestModel), Encoding.UTF8, "application/json");

                using HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string jsonBusLocationResponseModel = await httpResponseMessage.Content.ReadAsStringAsync();

                BusLocationResponseModel busLocationResponseModel = JsonConvert.DeserializeObject<BusLocationResponseModel>(jsonBusLocationResponseModel);

                if (busLocationResponseModel.Status != "Success") throw new HttpRequestException(busLocationResponseModel.Message);

                return busLocationResponseModel.Data;
            }
            catch
            {
                throw;
            }
        }

        private async Task<SessionResponseModel> getSession()
        {
            try
            {
                using HttpClient httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient.DefaultRequestHeaders.Add("Authorization", configuration.GetSection("Authorization").Value);

                using SessionRequestModel sessionRequestModel = new SessionRequestModel();

                using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(RequestAddres.GetSession));

                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(sessionRequestModel), Encoding.UTF8, "application/json");

                using HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string jsonSessionResponseModel = await httpResponseMessage.Content.ReadAsStringAsync();

                using SessionResponseModel sessionResponseModel = JsonConvert.DeserializeObject<SessionResponseModel>(jsonSessionResponseModel);

                if (sessionResponseModel.Status != "Success") throw new HttpRequestException(sessionResponseModel.Message);

                return sessionResponseModel;
            }
            catch
            {
                throw;
            }
        }
    }
}
