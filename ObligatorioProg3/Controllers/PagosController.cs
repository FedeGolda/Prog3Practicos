using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;

namespace ObligatorioProg3.Controllers
{
    public class PagosController : Controller
    {
        private readonly ObligatorioP3V2Context _context;

        public PagosController(ObligatorioP3V2Context context)
        {
            _context = context;
        }

        // GET: Pagos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var obligatorioP3V2Context = _context.Pagos.Include(p => p.Cliente).Include(p => p.Clima).Include(p => p.Reserva);
            return View(await obligatorioP3V2Context.ToListAsync());
        }

        // GET: Pagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Cliente)
                .Include(p => p.Clima)
                .Include(p => p.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["ClimaId"] = new SelectList(_context.Climas, "Id", "Id");
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "ClienteId");
            return View();
        }

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReservaId,ClienteId,ClimaId,Monto,FechaPago,MetodoPago,TasaCambio,Moneda,MontoConvertido,PrecioTotal")] Pago pago)
        {
            if (!ModelState.IsValid)
            {
                // Obtener el cliente para calcular el descuento
                var cliente = await _context.Clientes.FindAsync(pago.ClienteId);
                if (cliente != null)
                {
                    // Calcular el precio total con descuento
                    pago.PrecioTotal = cliente.CalcularDescuento(pago.Monto);
                }

                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", pago.ClienteId);
            ViewData["ClimaId"] = new SelectList(_context.Climas, "Id", "Id", pago.ClimaId);
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id", pago.ReservaId);
            return View(pago);
        }

        // GET: Pagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", pago.ClienteId);
            ViewData["ClimaId"] = new SelectList(_context.Climas, "Id", "Id", pago.ClimaId);
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id", pago.ReservaId);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReservaId,ClienteId,ClimaId,Monto,FechaPago,MetodoPago,TasaCambio,Moneda,MontoConvertido,PrecioTotal")] Pago pago)
        {
            if (id != pago.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    // Obtener el cliente para calcular el descuento
                    var cliente = await _context.Clientes.FindAsync(pago.ClienteId);
                    if (cliente != null)
                    {
                        // Calcular el precio total con descuento
                        pago.PrecioTotal = cliente.CalcularDescuento(pago.Monto);
                    }

                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id", pago.ClienteId);
            ViewData["ClimaId"] = new SelectList(_context.Climas, "Id", "Id", pago.ClimaId);
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "Id", "Id", pago.ReservaId);
            return View(pago);
        }

        // GET: Pagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Cliente)
                .Include(p => p.Clima)
                .Include(p => p.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
