using WeatherApp.Data;

namespace WeatherApp.Logic
{
    public static class WeatherCategorizer
    {
        public static string GetTemperatureCategory(double celsius)
        {
            if (celsius < 0)  return "Freezing";
            if (celsius < 15) return "Cold";
            if (celsius < 25) return "Mild";
            if (celsius < 35) return "Warm";
            return "Hot";
        }

        public static string GetOverallCategory(WeatherData data)
        {
            if (data.IsRaining) return "Rainy";
            return GetTemperatureCategory(data.TemperatureCelsius);
        }
    }
}