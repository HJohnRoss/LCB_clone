using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// NOTE: Adding Web API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5067/api/") });


await builder.Build().RunAsync();
