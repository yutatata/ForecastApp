using ForecastApp.Config;
using ForecastApp.DisastersAPIModel;
using ForecastApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;

namespace ForecastApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var eventList = GetDisasters();
        
            return View(eventList);
        }

        [NonAction]
        public List<DisasterEvent> GetDisasters()
        {
            var client = new RestClient();
            var request = new RestRequest(Constants.DisasterAPIUri, method: Method.Get);

            request.AddHeader("Authorization", "Bearer " + Constants.DisasterAccessToken);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("country", "TR");
            request.AddParameter("category", "disasters");

            RestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                try
                {
                    var x = response.Content;
                    var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                    var r = content.ToObject<DisastersResponse>();
                    var result = r.Results;
                    return result;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return null;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
