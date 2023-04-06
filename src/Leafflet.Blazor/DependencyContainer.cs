namespace Leaflet.Blazor;
public static class DependencyContainer
{
    public static IServiceCollection AddLeafletService(this IServiceCollection services)
    {
        services.AddSingleton<LeafletService>();
        return services;
    }
}