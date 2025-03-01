/*
 * useful links
 * https://www.mudblazor.com/docs/overview
 */


using MudBlazor.Services;
using LoneWorkerCheckin.Blazor.Components;
using LoneWorkerCheckin.Api.Client;
using Refit;
using LoneWorkerCheckin.Blazor.ViewModels;
using LoneWorkerCheckin.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// NOTE:
// Design build configuration was cloned from debug and defines the DESIGN conditional compliation arg
// This is used to replace the real ApiClient in DI with a mock containing sample data to
// allow Blazor quick startup time when doing UI design hot reload.
#if DESIGN

builder.Services.AddScoped<ILoneWorkerCheckinApiClient, DesignTimeLoneWorkerCheckinApiClient>();

#else

builder.Services.AddRefitClient<ILoneWorkerCheckinApiClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https+http://loneworkercheckin-api"));

#endif

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<CheckinPageViewModel>();
builder.Services.AddTransient<StartTaskComponentViewModel>();

//JS Interop
builder.Services.AddScoped<IGeoLocationBroker, GeoLocationBroker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
