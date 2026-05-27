using Microsoft.EntityFrameworkCore;
using ProBecasW.Data;
using ProBecasW.Services;
using ProBecasW.Data;
using ProBecasW.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar el servicio de evaluación
builder.Services.AddScoped<IBecaService, BecaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Becas}/{action=Index}/{id?}");

// Habilita los endpoints de la API
app.MapControllers();

app.Run();