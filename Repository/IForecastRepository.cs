using ForecastApp.OpenWeatherAppModels;

namespace ForecastApp.Repository
{
    public interface IForecastRepository
    {
        WeatherResponse GetForecast(string city);

    }
}
