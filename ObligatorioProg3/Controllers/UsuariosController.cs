using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;
using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string contraseña, string? returnUrl = null)
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

            // Invalida la caché del cliente
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";

            // Redirige al usuario a la página originalmente solicitada o a la página de inicio si no hay ninguna
            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Invalida la caché del cliente
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
