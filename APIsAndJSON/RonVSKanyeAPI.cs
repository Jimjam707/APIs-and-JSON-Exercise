using Newtonsoft.Json.Linq;
namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        private HttpClient client = new HttpClient();

        public string GetRonSwansonQuote()
        {
            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            return ronQuote;
        }

        public string GetKanyeWestQuote()
        {
            var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
            var kanyeQuote = JObject.Parse(kanyeResponse)["quote"]?.ToString();
            return kanyeQuote;
        }
    }
}
