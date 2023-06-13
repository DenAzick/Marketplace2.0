using IdentityMudBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7032") });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
