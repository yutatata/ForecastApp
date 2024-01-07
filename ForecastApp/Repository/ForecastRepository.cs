using ForecastApp.OpenWeatherAppModels;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using ForecastApp.Config;
using Constants = ForecastApp.Config.Constants;


namespace ForecastApp.Repository
{
    public class ForecastRepository : IForecastRepository
    {
        public WeatherResponse GetForecast(string city)
        {
            string IDOWeather = Constants.OPEN_WEATHER_APPID;
            // Connection String
            var client = new RestClient();
            var request = new RestRequest($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={IDOWeather}", method:Method.Get);
            RestResponse response = client.Execute(request);
             
            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResponse>();
            }

            return null;


        }
    }
}
