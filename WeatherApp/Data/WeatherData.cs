namespace WeatherApp.Data
{
    public class WeatherData
    {
        public string City { get; set; }
        public double TemperatureCelsius { get; set; }
        public int Humidity { get; set; }
        public double WindSpeedKmh { get; set; }
        public bool IsRaining { get; set; }

        public WeatherData(string city, double temperatureCelsius, int humidity, double windSpeedKmh, bool isRaining)
        {
            City = city;
            TemperatureCelsius = temperatureCelsius;
            Humidity = humidity;
            WindSpeedKmh = windSpeedKmh;
            IsRaining = isRaining;
        }
    }
}