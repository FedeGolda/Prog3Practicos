using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ObligatorioProg3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ObligatorioProg3.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ObligatorioP3Context _context;

        public UsuariosController(ObligatorioP3Context context)
        {
            _context = context;
        }

        // GET: Usuarios/Index
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        // GET: Usuarios/Login
        public IActionResult Login(string? returnUrl = null) // Cambiado a string?
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string contraseña, string? returnUrl = null) // Cambiado a string?
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Contraseña == contraseña);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Correo electrónico o contraseña incorrectos.");
                return View();
            }

            // Autenticación exitosa
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                // Aquí puedes agregar más claims según tus necesidades
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                // Puedes establecer propiedades adicionales aquí si es necesario
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Redirige al usuario a la página originalmente solicitada o a la página de inicio si no hay ninguna
            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string? returnUrl) // Cambiado a string?
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        // Otros métodos del controlador...

        // GET: Usuarios/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Usuarios/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Nombre,Email,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (_context.Usuarios.Any(u => u.Email == usuario.Email))
                {
                    ModelState.AddModelError("Email", "Este correo ya está registrado.");
                    return View(usuario);
                }

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(usuario);
        }

        // GET: Usuarios/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
