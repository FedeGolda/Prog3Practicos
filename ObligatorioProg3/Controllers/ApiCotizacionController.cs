using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObligatorioProg3.Models;
using RestSharp;
using System;

namespace ObligatorioProg3.Controllers
{
    public class ApiCotizacionController : Controller
    {
        public IActionResult GetCotizacion()
        {
            try
            {
                var client = new RestClient("http://apilayer.net/api/live");
                var request = new RestRequest("?access_key=9cccd6e24e3754cff44dd4c96aed2041&source=USD&format=1");
                RestResponse response = client.ExecuteGet(request);

                if (response.IsSuccessful)
                {
                    ApiCotizacionModel USDaMonedas = JsonConvert.DeserializeObject<ApiCotizacionModel>(response.Content);
                    ViewBag.USDaMonedas = USDaMonedas;
                }
                else
                {
                    ViewBag.USDaMonedas = null;
                    // Loguear el error o manejarlo de alguna manera
                    Console.WriteLine("Error al obtener la cotización: " + response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                ViewBag.USDaMonedas = null;
                // Loguear el error o manejarlo de alguna manera
                Console.WriteLine("Excepción al obtener la cotización: " + ex.Message);
            }

            return View("ApiButton");
        }
    }
}
