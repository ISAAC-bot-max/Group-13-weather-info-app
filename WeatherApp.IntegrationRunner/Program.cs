
using System.Globalization;
using WeatherApp.Data;
using WeatherApp.Logic;

int passed = 0, failed = 0;

string Num(double d) => (Math.Round(d, 2) + 0.0).ToString("0.##", CultureInfo.InvariantCulture);

void Check(string id, string test, string expected, string actual)
{
    bool ok = expected == actual;
    if (ok) passed++; else failed++;
    Console.WriteLine($"{id}  {(ok ? "PASS" : "FAIL")}  {test}");
    Console.WriteLine($"        Expected: {expected}");
    Console.WriteLine($"        Actual:   {actual}\n");
}

Console.WriteLine("===== INTEGRATION TESTS =====\n");
var repo = new WeatherRepository();

// IT-01: Repository + Categorizer
var cats = repo.GetAll().Select(w => $"{w.City} {WeatherCategorizer.GetOverallCategory(w)}");
Check("IT-01", "Repository + Categorizer (all 8 records)",
      "Lagos Warm, Abuja Rainy, Kano Hot, Jos Mild, London Rainy, Moscow Freezing, Dubai Hot, New York Cold",
      string.Join(", ", cats));

// IT-02 to IT-04: Repository + Converter
string Conv(string city)
{
    var w = repo.FindByCity(city)!;
    return $"{Num(TemperatureConverter.CelsiusToFahrenheit(w.TemperatureCelsius))} F and {Num(TemperatureConverter.CelsiusToKelvin(w.TemperatureCelsius))} K";
}
Check("IT-02", "Repository + Converter: Lagos (31 C)", "87.8 F and 304.15 K", Conv("Lagos"));
Check("IT-03", "Repository + Converter: Moscow (-8 C)", "17.6 F and 265.15 K", Conv("Moscow"));
Check("IT-04", "Repository + Converter: Dubai (42 C)", "107.6 F and 315.15 K", Conv("Dubai"));

Console.WriteLine($"Total: {passed + failed}   Passed: {passed}   Failed: {failed}");