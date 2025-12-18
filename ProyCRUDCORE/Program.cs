using Microsoft.EntityFrameworkCore;
using ProyCRUDCORE;
using ProyCRUDCORE.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agregando los Servicios necesarios
builder.Services.AddDbContext<DbcrudcoreContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
