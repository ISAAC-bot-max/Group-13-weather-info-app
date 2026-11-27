using System.Globalization;
using WeatherApp.Data;
using WeatherApp.Logic;

int passed = 0, failed = 0;

string Num(double d) => (Math.Round(d, 2) + 0.0).ToString("0.##", CultureInfo.InvariantCulture);

void Check(string id, string test, string expected, string actual)
{
    bool ok = expected == actual;
    if (ok) passed++; else failed++;
    Console.WriteLine($"{id,-7}{(ok ? "PASS" : "FAIL"),-6}{test,-40}Expected: {expected,-20}Actual: {actual}");
}

Console.WriteLine("===== UNIT TESTS =====");

// Temperature converter
Check("UT-01", "CelsiusToFahrenheit(100)", "212", Num(TemperatureConverter.CelsiusToFahrenheit(100)));
Check("UT-02", "CelsiusToFahrenheit(0)", "32", Num(TemperatureConverter.CelsiusToFahrenheit(0)));
Check("UT-03", "CelsiusToFahrenheit(-40)", "-40", Num(TemperatureConverter.CelsiusToFahrenheit(-40)));
Check("UT-04", "CelsiusToKelvin(0)", "273.15", Num(TemperatureConverter.CelsiusToKelvin(0)));
Check("UT-05", "CelsiusToKelvin(-273.15)", "0", Num(TemperatureConverter.CelsiusToKelvin(-273.15)));
Check("UT-06", "FahrenheitToCelsius(212)", "100", Num(TemperatureConverter.FahrenheitToCelsius(212)));
Check("UT-07", "FahrenheitToCelsius(32)", "0", Num(TemperatureConverter.FahrenheitToCelsius(32)));
Check("UT-08", "KelvinToCelsius(273.15)", "0", Num(TemperatureConverter.KelvinToCelsius(273.15)));
Check("UT-09", "KelvinToCelsius(0)", "-273.15", Num(TemperatureConverter.KelvinToCelsius(0)));

// Weather categorizer
Check("UT-10", "GetTemperatureCategory(-8)", "Freezing", WeatherCategorizer.GetTemperatureCategory(-8));
Check("UT-11", "GetTemperatureCategory(0)", "Cold", WeatherCategorizer.GetTemperatureCategory(0));
Check("UT-12", "GetTemperatureCategory(14.9)", "Cold", WeatherCategorizer.GetTemperatureCategory(14.9));
Check("UT-13", "GetTemperatureCategory(15)", "Mild", WeatherCategorizer.GetTemperatureCategory(15));
Check("UT-14", "GetTemperatureCategory(25)", "Warm", WeatherCategorizer.GetTemperatureCategory(25));
Check("UT-15", "GetTemperatureCategory(34.9)", "Warm", WeatherCategorizer.GetTemperatureCategory(34.9));
Check("UT-16", "GetTemperatureCategory(35)", "Hot", WeatherCategorizer.GetTemperatureCategory(35));
Check("UT-17", "GetOverallCategory(Abuja, raining)", "Rainy",
      WeatherCategorizer.GetOverallCategory(new WeatherData("Abuja", 28.5, 60, 10.0, true)));
Check("UT-18", "GetOverallCategory(Lagos, not raining)", "Warm",
      WeatherCategorizer.GetOverallCategory(new WeatherData("Lagos", 31.0, 78, 14.5, false)));

// Weather repository
var repo = new WeatherRepository();
Check("UT-19", "GetAll() record count", "8", repo.GetAll().Count.ToString());
var lagos = repo.FindByCity("Lagos");
Check("UT-20", "FindByCity(\"Lagos\")", "Lagos 31", lagos == null ? "null" : $"{lagos.City} {Num(lagos.TemperatureCelsius)}");
Check("UT-21", "FindByCity(\"  lagos  \")", "Lagos", repo.FindByCity("  lagos  ")?.City ?? "null");
Check("UT-22", "FindByCity(\"Paris\")", "null", repo.FindByCity("Paris")?.City ?? "null");
Check("UT-23", "FindByCity(\"\")", "null", repo.FindByCity("")?.City ?? "null");

Console.WriteLine($"\nTotal: {passed + failed}   Passed: {passed}   Failed: {failed}");