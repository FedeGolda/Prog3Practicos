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
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Opcional: Configura el tiempo de expiración de la cookie
                options.SlidingExpiration = true; // Opcional: Extiende el tiempo de expiración de la cookie con cada solicitud
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "usuarios",
                pattern: "{controller=Usuarios}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
