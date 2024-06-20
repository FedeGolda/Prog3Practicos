using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Asegúrate de tener esta importación

public class ClientesController : Controller
{
    private readonly ObligatorioP3Context _context;
    private readonly ILogger<ClientesController> _logger;

    public ClientesController(ObligatorioP3Context context, ILogger<ClientesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: Clientes
    public async Task<IActionResult> Index()
    {
        var obligatorioP3Context = _context.Clientes.Include(c => c.Usuario);
        return View(await obligatorioP3Context.ToListAsync());
    }

    // GET: Clientes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cliente = await _context.Clientes
            .Include(c => c.Usuario)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // GET: Clientes/Create
    public IActionResult Create()
    {
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
        return View();
    }

    // POST: Clientes/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UsuarioId,Nombre,Email,TipoCliente")] Cliente cliente)
    {
        _logger.LogInformation("Entrando en el método Create POST");

        if (!ModelState.IsValid)
        {
            try
            {
                _logger.LogInformation("ModelState es válido, intentando agregar cliente");
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Cliente creado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear el cliente: {0}", ex.Message);
                ModelState.AddModelError("", $"Error al crear el cliente: {ex.Message}");
            }
        }
        else
        {
            _logger.LogWarning("ModelState no es válido");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
        }

        _logger.LogInformation("Regresando a la vista Create debido a un error");
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", cliente.UsuarioId);
        return View(cliente);
    }

    // GET: Clientes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", cliente.UsuarioId);
        return View(cliente);
    }

    // POST: Clientes/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,Nombre,Email,TipoCliente")] Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Cliente editado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al editar el cliente: {0}", ex.Message);
                ModelState.AddModelError("", $"Error al editar el cliente: {ex.Message}");
            }
        }

        ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", cliente.UsuarioId);
        return View(cliente);
    }

    // GET: Clientes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cliente = await _context.Clientes
            .Include(c => c.Usuario)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    // POST: Clientes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null)
        {
            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Cliente eliminado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al eliminar el cliente: {0}", ex.Message);
                ModelState.AddModelError("", $"Error al eliminar el cliente: {ex.Message}");
            }
        }
        return RedirectToAction(nameof(Index));
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}
