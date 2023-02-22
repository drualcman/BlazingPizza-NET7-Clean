using BlazingPizza.BussinesObjects.ValueObjects.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazingPizzaFrontendServices(builder.Configuration.GetSection("BlazzingPizzaEndpoint").Get<EndpointsOptions>());

await builder.Build().RunAsync();
