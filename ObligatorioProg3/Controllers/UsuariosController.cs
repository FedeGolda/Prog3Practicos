using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Asegúrate de tener esta importación

public class UsuariosController : Controller
{
    private readonly ObligatorioP3Context _context;
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(ObligatorioP3Context context, ILogger<UsuariosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: Usuarios
    public async Task<IActionResult> Index()
    {
        var obligatorioP3Context = _context.Usuarios.Include(u => u.Rol);
        return View(await obligatorioP3Context.ToListAsync());
    }

    // GET: Usuarios/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.Usuarios
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // GET: Usuarios/Create
    public IActionResult Create()
    {
        ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre");
        return View();
    }

    // POST: Usuarios/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Contraseña,RolId")] Usuario usuario)
    {
        _logger.LogInformation("Entrando en el método Create POST");

        if (!ModelState.IsValid)
        {
            _logger.LogWarning("ModelState no es válido");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            _logger.LogInformation("ModelState es válido, intentando agregar usuario");
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Usuario creado exitosamente");
            return RedirectToAction(nameof(Index));
        }

        if (ModelState.IsValid)
        {
            try
            {
             
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear el usuario: {0}", ex.Message);
                ModelState.AddModelError("", $"Error al crear el usuario: {ex.Message}");
            }
        }

        // Si hay un error, pasa nuevamente los roles a la vista
        ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre", usuario.RolId);
        _logger.LogInformation("Regresando a la vista Create debido a un error");
        return View(usuario);
    }

    // GET: Usuarios/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre", usuario.RolId);
        return View(usuario);
    }

    // POST: Usuarios/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Contraseña,RolId")] Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.Id))
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
                ModelState.AddModelError("", $"Error al editar el usuario: {ex.Message}");
            }
        }

        ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Nombre", usuario.RolId);
        return View(usuario);
    }

    // GET: Usuarios/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var usuario = await _context.Usuarios
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // POST: Usuarios/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            try
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar el usuario: {ex.Message}");
            }
        }
        return RedirectToAction(nameof(Index));
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}
