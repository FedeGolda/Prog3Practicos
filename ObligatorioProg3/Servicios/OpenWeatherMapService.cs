using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Servicios
{
    public class OpenWeatherMapService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenWeatherMapService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<Clima> GetClimaAsync(string city)
        {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(jsonString);
                return new Clima
                {
                    Temperatura = (short)json["main"]["temp"].Value<float>(),
                    DescripcionClima = json["weather"].First["description"].Value<string>()
                };
            }

            return null;
        }
    }
}
