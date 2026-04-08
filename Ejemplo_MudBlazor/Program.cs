using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;
using Ejemplo_MudBlazor.Components;
using Ejemplo_MudBlazor.ViewModels;
using Ejemplo_MudBlazor.Interfaces;
using Ejemplo_MudBlazor.Data.Repositories;
using Ejemplo_MudBlazor.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 45)); 
builder.Services.AddDbContext<ReunionContext>(options => options.UseMySql(connectionString, serverVersion));

builder.Services.AddScoped<IReunionRepository, ReunionRepository>();
builder.Services.AddScoped<ListaViewModel>();
builder.Services.AddScoped<DetalleViewModel>();
builder.Services.AddScoped<FormViewModel>();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
