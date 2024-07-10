using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObligatorioProg3.Models;
using RestSharp;

namespace ObligatorioProg3.Controllers
{
    public class ApiClimaController : Controller
    {
        public IActionResult GetClima()
        {
            var client = new RestClient("https://api.openweathermap.org/data");
            var request = new RestRequest("/2.5/weather?lat=-34.9087162&lon=-54.9582718&appid=9cccd6e24e3754cff44dd4c96aed2041&units=metric");
            RestResponse response = client.ExecuteGet(request);

            if (response.IsSuccessful && response.Content != null)
            {
                System.Diagnostics.Debug.WriteLine("API Response Content:");
                System.Diagnostics.Debug.WriteLine(response.Content);

                var clima = JsonConvert.DeserializeObject<ApiClimaModel>(response.Content);

                if (clima != null && clima.Main != null)
                {
                    System.Diagnostics.Debug.WriteLine("Temperature:");
                    System.Diagnostics.Debug.WriteLine(clima.Main.Temp);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Deserialization issue: clima or clima.Main is null");
                }

                ViewBag.ElClima = clima;
                return View("Index", clima);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("API Request Failed:");
                System.Diagnostics.Debug.WriteLine(response.ErrorMessage);
                ViewBag.ElClima = null;
                return View("Index");
            }
        }
    }
}
