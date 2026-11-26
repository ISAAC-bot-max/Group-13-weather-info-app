namespace WeatherApp.Logic
{
    public static class TemperatureConverter
    {
        public static double CelsiusToFahrenheit(double c) => (c * 9.0 / 5.0) + 32.0;
        public static double CelsiusToKelvin(double c) => c + 273.15;
        public static double FahrenheitToCelsius(double f) => (f - 32.0) * 5.0 / 9.0;
        public static double KelvinToCelsius(double k) => k - 273.15;
    }
}