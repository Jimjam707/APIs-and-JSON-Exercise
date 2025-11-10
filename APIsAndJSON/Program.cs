using Newtonsoft.Json.Linq;
namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var api = new RonVSKanyeAPI();
            
            Console.WriteLine("Ron Swanson and Kanye West Conversation:\n");
            Console.WriteLine(new string('-', 60));
            
            for (int i = 0; i < 5; i++)
            {
                var ronQuote = api.GetRonSwansonQuote();
                Console.WriteLine($"\nRon Swanson: {ronQuote}");
                
                var kanyeQuote = api.GetKanyeWestQuote();
                Console.WriteLine($"\nKanye West: {kanyeQuote}");
                
                Console.WriteLine(new string('-', 60));
            }
            
            Console.WriteLine("\n\nNow let's check the weather!\n");
            
            var apiKey = "b1b2e8769deb842d779145148f91bfdc";
            var weatherAPI = new OpenWeatherMapAPI(apiKey);
            
            weatherAPI.GetCurrentWeatherByCoordinates(36.1627, -86.7816);
           
        }
        
    }
}

