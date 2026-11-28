# Group-13-weather-info-app

## Weather Information Application (C# Console App)

Group 13 software engineering project. The app displays weather information from a predefined dataset of eight cities, with temperature conversion and weather categories.

 Features
- View all cities with Celsius, Fahrenheit and weather category
- Search weather by city name (not case-sensitive)
- Convert temperatures: Celsius to Fahrenheit, Celsius to Kelvin, Fahrenheit to Celsius, Kelvin to Celsius
- Weather categories: Freezing, Cold, Mild, Warm, Hot and Rainy
- Input validation with clear error messages

Requirements
- .NET 9 SDK (check with `dotnet --version`)
- Git

## How to run
```
git clone https://github.com/ISAAC-bot-max/Group-13-weather-info-app.git
cd Group-13-weather-info-app/WeatherApp
dotnet run
```

 How to run the tests (optional)
From the top folder of the repository:
```
dotnet run --project WeatherApp.TestRunner
dotnet run --project WeatherApp.IntegrationRunner
```

 Project structure
```
WeatherApp/
  Data/    WeatherData.cs, WeatherRepository.cs
  Logic/   TemperatureConverter.cs, WeatherCategorizer.cs
  UI/      ConsoleMenu.cs
  Program.cs
WeatherApp.TestRunner/         unit tests
WeatherApp.IntegrationRunner/  integration tests
```

## Group members
| Name               | Matric number |            Role                |

| Oyewole Isaac      | 25120112050 | Project Manager, C# Developer (Data layer), QA/Tester |
| Apampa Oyinkansola | 25120112006 | Requirements Analyst, C# Developer (Logic layer) |
| Ileile Omuwa       | 25120112028 | System Modeller, C# Developer (UI layer) |
