using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PocketDDD.BlazorClient;
using PocketDDD.BlazorClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["apiUrl"]!) });
builder.Services.AddMudServices();
builder.Services.AddFluxor(o => o.ScanAssemblies(typeof(Program).Assembly).UseReduxDevTools());
builder.Services.AddBlazoredLocalStorage();

if (builder.Configuration.GetValue<bool>("fakeBackend") == false)
    builder.Services.AddScoped<IPocketDDDApiService, PocketDDDApiService>();
else
    builder.Services.AddScoped<IPocketDDDApiService, FakePocketDDDApiService>();

await builder.Build().RunAsync();