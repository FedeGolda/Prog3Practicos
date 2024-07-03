using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObligatorioProg3.Models;
using RestSharp;

namespace ObligatorioProg3.Controllers
{
    public class ApiCotizacionController : Controller
    {
        public IActionResult GetCotizacion()
        {

            var client = new RestClient("http://apilayer.net/api/live");
            var request = new RestRequest("?access_key=3d45b85f1d114f7c1a75afbad0ca81cb&source=USD&format=1");
            RestResponse response = client.ExecuteGet(request);
            ApiCotizacionModel USDaMonedas = JsonConvert.DeserializeObject<ApiCotizacionModel>(response.Content);
            
            ViewBag.USDaMonedas = USDaMonedas;

            return View("ApiButton");


        }
    }
}
