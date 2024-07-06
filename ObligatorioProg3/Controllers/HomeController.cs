using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObligatorioProg3.Models;
using RestSharp;
using System.Diagnostics;

namespace ObligatorioProg3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var client = new RestClient("http://apilayer.net/api/live");
                var request = new RestRequest("?access_key=3d45b85f1d114f7c1a75afbad0ca81cb&source=USD&format=1");
                RestResponse response = client.ExecuteGet(request);

                if (response.IsSuccessful)
                {
                    ApiCotizacionModel USDaMonedas = JsonConvert.DeserializeObject<ApiCotizacionModel>(response.Content);
                    ViewBag.USDaMonedas = USDaMonedas;
                }
                else
                {
                    ViewBag.USDaMonedas = null;
                    _logger.LogError("Error al obtener la cotización: " + response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                ViewBag.USDaMonedas = null;
                _logger.LogError("Excepción al obtener la cotización: " + ex.Message);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
