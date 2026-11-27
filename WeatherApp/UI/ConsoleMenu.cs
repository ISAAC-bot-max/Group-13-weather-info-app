using WeatherApp.Data;
using WeatherApp.Logic;

namespace WeatherApp.UI
{
    public class ConsoleMenu
    {
        private readonly WeatherRepository _repo = new WeatherRepository();

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n===== WEATHER INFORMATION APP =====");
                Console.WriteLine("1. View all cities");
                Console.WriteLine("2. Search weather by city");
                Console.WriteLine("3. Convert a temperature");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1": ShowAll(); break;
                    case "2": SearchCity(); break;
                    case "3": ConvertTemperature(); break;
                    case "4": running = false; Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid option. Enter 1-4."); break;
                }
            }
        }

        private void ShowAll()
        {
            Console.WriteLine($"\n{"City",-10}{"Temp(C)",-10}{"Temp(F)",-10}{"Category",-10}");
            foreach (var w in _repo.GetAll())
            {
                double f = TemperatureConverter.CelsiusToFahrenheit(w.TemperatureCelsius);
                Console.WriteLine($"{w.City,-10}{w.TemperatureCelsius,-10:F1}{f,-10:F1}{WeatherCategorizer.GetOverallCategory(w),-10}");
            }
        }

        private void SearchCity()
        {
            Console.Write("Enter city name: ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("City name cannot be empty.");
                return;
            }

            var w = _repo.FindByCity(input);
            if (w == null)
            {
                Console.WriteLine("City not found in dataset.");
                return;
            }

            Console.WriteLine($"\nCity:        {w.City}");
            Console.WriteLine($"Celsius:     {w.TemperatureCelsius:F1} C");
            Console.WriteLine($"Fahrenheit:  {TemperatureConverter.CelsiusToFahrenheit(w.TemperatureCelsius):F1} F");
            Console.WriteLine($"Kelvin:      {TemperatureConverter.CelsiusToKelvin(w.TemperatureCelsius):F2} K");
            Console.WriteLine($"Humidity:    {w.Humidity}%");
            Console.WriteLine($"Wind:        {w.WindSpeedKmh} km/h");
            Console.WriteLine($"Raining:     {(w.IsRaining ? "Yes" : "No")}");
            Console.WriteLine($"Temp class:  {WeatherCategorizer.GetTemperatureCategory(w.TemperatureCelsius)}");
            Console.WriteLine($"Overall:     {WeatherCategorizer.GetOverallCategory(w)}");
        }

        private void ConvertTemperature()
        {
            Console.WriteLine("\n1. Celsius -> Fahrenheit");
            Console.WriteLine("2. Celsius -> Kelvin");
            Console.WriteLine("3. Fahrenheit -> Celsius");
            Console.WriteLine("4. Kelvin -> Celsius");
            Console.Write("Choose conversion: ");
            string? choice = Console.ReadLine()?.Trim();

            if (choice is not ("1" or "2" or "3" or "4"))
            {
                Console.WriteLine("Invalid conversion option.");
                return;
            }

            Console.Write("Enter value: ");
            if (!double.TryParse(Console.ReadLine(), out double value))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            if ((choice == "2" && value < -273.15) || (choice == "4" && value < 0))
            {
                Console.WriteLine("Value is below absolute zero.");
                return;
            }

            double result = choice switch
            {
                "1" => TemperatureConverter.CelsiusToFahrenheit(value),
                "2" => TemperatureConverter.CelsiusToKelvin(value),
                "3" => TemperatureConverter.FahrenheitToCelsius(value),
                _   => TemperatureConverter.KelvinToCelsius(value)
            };
            Console.WriteLine($"Result: {result:F2}");
        }
    }
}