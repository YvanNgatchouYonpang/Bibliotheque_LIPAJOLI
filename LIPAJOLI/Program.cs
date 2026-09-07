using LIPAJOLI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<LIPAJOLI.Interfaces.IEmpruntApiService, LIPAJOLI.Services.EmpruntApiService>(client => client.BaseAddress = new Uri(builder.Configuration["Api:BaseUrl"] ?? "https://localhost:7001/"));

// Configuration Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context =
            services.GetRequiredService<ApplicationDbContext>();

        DbInitializer.Initialize(
            context,
            builder.Configuration);
    }
    catch (Exception ex)
    {
        var logger =
            services.GetRequiredService<ILogger<Program>>();

        logger.LogError(
            ex,
            "Une erreur est survenue lors de la cr�ation de la base de donn�es.");
    }
}

app.Run();