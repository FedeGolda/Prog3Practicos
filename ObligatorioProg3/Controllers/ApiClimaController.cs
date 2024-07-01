using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;
using ObligatorioProg3.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ObligatorioProg3.Controllers
{
    public class ApiClimaController : Controller
    {
       
        public IActionResult GetClima()
        {

            var client = new RestClient("https://api.openweathermap.org/data");
            var request = new RestRequest("/2.5/weather?lat=-34.9087162&lon=-54.9582718&appid=9cccd6e24e3754cff44dd4c96aed2041&units=metric");
            RestResponse response = client.ExecuteGet(request);
            ApiClimaModel ElClima = JsonConvert.DeserializeObject<ApiClimaModel>(response.Content);

            ViewBag.ElClima = ElClima;

            return View("ApiButton");


        }
    }
}
