using Ejemplo_Blazor_EF.Components;
using Ejemplo_Blazor_EF.ViewModels;
using Ejemplo_Blazor_EF.Interfaces;
using Ejemplo_Blazor_EF.Data.Repositories;
using Ejemplo_Blazor_EF.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configurar el DbContext con Pomelo MySQL.
builder.Services.AddDbContext<ReunionContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IReunionRepository, ReunionRepository>();
builder.Services.AddTransient<ListaViewModel>();
builder.Services.AddTransient<DetalleViewModel>();
builder.Services.AddTransient<FormViewModel>();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
