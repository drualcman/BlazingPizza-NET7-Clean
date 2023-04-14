using Microsoft.Extensions.DependencyInjection;

namespace Geolocation.Blazor;
public static class DependencyContainer
{
    public static IServiceCollection AddGeolocationService(this IServiceCollection services)
    {
        services.AddSingleton<GeolocationService>();
        return services;
    }
}