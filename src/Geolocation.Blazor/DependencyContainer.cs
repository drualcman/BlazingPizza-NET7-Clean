using Geolocation.Blazor.Geocoding;
using Geolocation.Blazor.Geocoding.Geoapify;
using Geolocation.Blazor.Geocoding.Geocode;
using Microsoft.Extensions.DependencyInjection;

namespace Geolocation.Blazor;
public static class DependencyContainer
{
    public static IServiceCollection AddGeolocationService(this IServiceCollection services)
    {
        services.AddSingleton<GeolocationService>();
        services.AddHttpClient<IGeocoder, GeocodeGeocoder>(httpClient =>
        {
            return new GeocodeGeocoder(httpClient);
        });
        return services;
    } 

    public static IServiceCollection AddDefaultGeocoderService(this IServiceCollection services, string geoCoderApiKey)
    {                                     
        services.AddSingleton<GeolocationService>();
        services.AddHttpClient<IGeocoder, GeoapifyGeocoder>(httpClient => 
        {
            return new GeoapifyGeocoder(httpClient, geoCoderApiKey);
        });
        return services;
    }
}