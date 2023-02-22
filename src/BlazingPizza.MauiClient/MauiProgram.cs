using BlazingPizza.BussinesObjects.ValueObjects.Options;
using Microsoft.Extensions.Configuration;

namespace BlazingPizza.MauiClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        using Stream configurationStream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
        builder.Configuration.AddJsonStream(configurationStream);

        Action<IHttpClientBuilder> configurator;
#if ANDROID || IOS
        configurator = configurator =>
        {
            Services.HttpsClientHandlerService handlerService = new Services.HttpsClientHandlerService();
            configurator.ConfigurePrimaryHttpMessageHandler(() => handlerService.GetPlatformMessageHandler());
        };
#else
        configurator = null;
#endif
        EndpointsOptions endpoints = builder.Configuration.GetSection("BlazzingPizzaEndpoint:others").Get<EndpointsOptions>();
#if ANDROID
    endpoints = builder.Configuration.GetSection("BlazzingPizzaEndpoint:android").Get<EndpointsOptions>();
    
#endif
        builder.Services.AddBlazingPizzaFrontendServices(endpoints, configurator);

        return builder.Build();
    }
}