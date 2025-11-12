using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        private HttpClient client = new HttpClient();
        private string apiKey;

        public OpenWeatherMapAPI(string key)
        {
            apiKey = key;
        }

        public void GetCurrentWeather(string city)
        {
            try
            {
                var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";
                
                var response = client.GetStringAsync(url).Result;
                var weatherData = JObject.Parse(response);

                DisplayWeather(weatherData);
            }
            catch (AggregateException ex)
            {
                HandleError(ex);
            }
        }

        public void GetCurrentWeatherByCoordinates(double lat, double lon)
        {
            try
            {
                var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=imperial";
                
                var response = client.GetStringAsync(url).Result;
                var weatherData = JObject.Parse(response);

                DisplayWeather(weatherData);
            }
            catch (AggregateException ex)
            {
                HandleError(ex);
            }
        }

        private void DisplayWeather(JObject weatherData)
        {
            var cityName = weatherData["name"]?.ToString();
            var country = weatherData["sys"]?["country"]?.ToString();
            var temperature = weatherData["main"]?["temp"]?.ToString();
            var feelsLike = weatherData["main"]?["feels_like"]?.ToString();
            var tempMin = weatherData["main"]?["temp_min"]?.ToString();
            var tempMax = weatherData["main"]?["temp_max"]?.ToString();
            var humidity = weatherData["main"]?["humidity"]?.ToString();
            var description = weatherData["weather"]?[0]?["description"]?.ToString();
            var windSpeed = weatherData["wind"]?["speed"]?.ToString();
            var cloudiness = weatherData["clouds"]?["all"]?.ToString();
            
            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine($"WEATHER FORECAST FOR {cityName?.ToUpper()}, {country}");
            Console.WriteLine(new string('=', 70));
            
            Console.WriteLine($"\nConditions: {description?.ToUpper()}");
            Console.WriteLine(new string('-', 70));
            
            Console.WriteLine($"\nTEMPERATURE:");
            Console.WriteLine($"    Current:     {temperature}°F");
            Console.WriteLine($"    Feels Like:  {feelsLike}°F");
            Console.WriteLine($"    High:        {tempMax}°F");
            Console.WriteLine($"    Low:         {tempMin}°F");
            
            Console.WriteLine($"\nHUMIDITY: {humidity}%");
            Console.WriteLine($"WIND SPEED: {windSpeed} mph");
            Console.WriteLine($"OVERCAST: {cloudiness}%");
            
            Console.WriteLine("\n" + new string('=', 70) + "\n");
        }

        private void HandleError(AggregateException ex)
        {
            
                Console.WriteLine("\nAn unexpected error occurred:");
                Console.WriteLine(ex.Message);
        }
    }
}

