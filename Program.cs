using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProyectoPrograAV2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add DbContext service with a direct connection string (Not recommended for production)
builder.Services.AddDbContext<DemoContext>(options =>
    options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=proyecto_tienda_G6;Trusted_Connection=True;TrustServerCertificate=True;"));

// Configure session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add any other necessary services.

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
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=tienda}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "historial",
    pattern: "Historial/HistorialUsuario/{id_usuario}",
    defaults: new { controller = "Historial", action = "HistorialUsuario" }
);

app.Run();