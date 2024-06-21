using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;

namespace ObligatorioProg3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the DbContext with the connection string from appsettings.json
            builder.Services.AddDbContext<ObligatorioP3V2Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ObligatorioP3_V2")));

            // Add authentication services
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Usuarios/Login"; // Configura tu ruta de inicio de sesión
                    options.LogoutPath = "/Usuarios/Logout"; // Configura tu ruta de cierre de sesión
                    options.AccessDeniedPath = "/Usuarios/AccessDenied"; // Configura tu ruta de acceso denegado
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Añadir el middleware de autenticación
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuarios}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
