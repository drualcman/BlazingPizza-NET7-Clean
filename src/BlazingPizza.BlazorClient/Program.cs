var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Options Pathern
EndpointsOptions endpoints = builder.Configuration.GetSection(EndpointsOptions.SectionKey).Get<EndpointsOptions>();
builder.Services.Configure<EndpointsOptions>(options => options = endpoints);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazingPizzaFrontendServices(Options.Create(endpoints));
builder.Services.AddScoped<IOrderStatusNotificator, OrderStatusNotificatorSimulator>();
builder.Services.AddMapsService();

await builder.Build().RunAsync();
