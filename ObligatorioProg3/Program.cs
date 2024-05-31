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

            // Register the DbContext with a connection string
            builder.Services.AddDbContext<ObligatorioP3Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configure authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Usuarios/Login";
                options.AccessDeniedPath = "/Usuarios/AccessDenied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Add this line to enable authentication
            app.UseAuthorization();

            // Las rutas adicionales para registro y login deben ir aquí antes de la ruta predeterminada
            app.MapControllerRoute(
                name: "register",
                pattern: "Usuarios/Register",
                defaults: new { controller = "Usuarios", action = "Register" });

            app.MapControllerRoute(
                name: "login",
                pattern: "Usuarios/Login",
                defaults: new { controller = "Usuarios", action = "Login" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuarios}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
