using Ejemplo_Blazor_MVVM.Components;
using Ejemplo_Blazor_MVVM.ViewModels;
using Ejemplo_Blazor_MVVM.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IReunionRepository, ReunionRepository>();
builder.Services.AddTransient<ListaViewModel>();
builder.Services.AddTransient<DetalleViewModel>();
builder.Services.AddTransient<FormViewModel>();
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
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
