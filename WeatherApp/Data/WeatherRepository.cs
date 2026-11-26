namespace WeatherApp.Data
{
    public class WeatherRepository
    {
        private readonly List<WeatherData> _records;

        public WeatherRepository()
        {
            _records = new List<WeatherData>
            {
                new WeatherData("Lagos",    31.0, 78, 14.5, false),
                new WeatherData("Abuja",    28.5, 60, 10.0, true),
                new WeatherData("Kano",     36.0, 30, 18.0, false),
                new WeatherData("Jos",      19.0, 55, 12.0, false),
                new WeatherData("London",   11.0, 82, 20.0, true),
                new WeatherData("Moscow",   -8.0, 70, 15.0, false),
                new WeatherData("Dubai",    42.0, 40,  9.0, false),
                new WeatherData("New York",  4.0, 65, 25.0, false)
            };
        }

        public List<WeatherData> GetAll() => _records;

        public WeatherData? FindByCity(string city)
        {
            return _records.FirstOrDefault(r =>
                r.City.Equals(city.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}