using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;
using ObligatorioProg3.Servicios;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioProg3.Controllers
{
    [Authorize]
    public class ClimasController : Controller
    {
        private readonly ObligatorioP3Context _context;
        private readonly OpenWeatherMapService _weatherService;

        public ClimasController(ObligatorioP3Context context, OpenWeatherMapService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        // GET: Climas/Index
        public async Task<IActionResult> Index()
        {
            var climas = await _context.Climas.ToListAsync();
            return View(climas);
        }

        // GET: Climas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clima = await _context.Climas.FirstOrDefaultAsync(m => m.Id == id);
            if (clima == null)
            {
                return NotFound();
            }

            return View(clima);
        }

        // GET: Climas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Climas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Temperatura,DescripcionClima")] Clima clima)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clima);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clima);
        }

        // GET: Climas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clima = await _context.Climas.FindAsync(id);
            if (clima == null)
            {
                return NotFound();
            }
            return View(clima);
        }

        // POST: Climas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Temperatura,DescripcionClima")] Clima clima)
        {
            if (id != clima.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clima);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClimaExists(clima.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clima);
        }

        // GET: Climas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clima = await _context.Climas.FirstOrDefaultAsync(m => m.Id == id);
            if (clima == null)
            {
                return NotFound();
            }

            return View(clima);
        }

        // POST: Climas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clima = await _context.Climas.FindAsync(id);
            if (clima != null)
            {
                _context.Climas.Remove(clima);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClimaExists(int id)
        {
            return _context.Climas.Any(e => e.Id == id);
        }

        // GET: Climas/GetClima
        public IActionResult GetClima()
        {
            return View();
        }

        // POST: Climas/GetClima
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetClima(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                ModelState.AddModelError("city", "Debe ingresar una ciudad válida.");
                var climas = await _context.Climas.ToListAsync();
                return View("Index", climas);
            }

            var clima = await _weatherService.GetClimaAsync(city);

            if (clima != null)
            {
                var nuevoClima = new Clima
                {
                    Fecha = DateTime.Now,
                    Temperatura = clima.Temperatura,
                    DescripcionClima = clima.DescripcionClima
                };

                _context.Add(nuevoClima);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Manejar error si no se puede obtener el clima
            ModelState.AddModelError(string.Empty, "No se pudo obtener el clima para la ciudad especificada.");
            var climasList = await _context.Climas.ToListAsync();
            return View("Index", climasList);
        }
    }
}
