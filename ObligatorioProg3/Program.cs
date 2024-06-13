using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ObligatorioProg3.Models;
using ObligatorioProg3.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext with a connection string
builder.Services.AddDbContext<ObligatorioP3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuarios/Login";
        options.AccessDeniedPath = "/Usuarios/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register the OpenWeatherMapService
builder.Services.AddHttpClient<OpenWeatherMapService>(client =>
{
    // Puedes configurar el cliente HTTP si es necesario
});

builder.Services.AddTransient<OpenWeatherMapService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var apiKey = configuration.GetValue<string>("OpenWeatherMap:ApiKey");
    return new OpenWeatherMapService(provider.GetRequiredService<HttpClient>(), apiKey);
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

app.UseSession(); // Asegúrate de que UseSession() esté después de UseAuthentication()

// Define las rutas de controlador
app.MapControllerRoute(
    name: "login",
    pattern: "/Usuarios/Login",
    defaults: new { controller = "Usuarios", action = "Login" });

app.MapControllerRoute(
    name: "logout",
    pattern: "/Usuarios/Logout",
    defaults: new { controller = "Usuarios", action = "Logout" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
