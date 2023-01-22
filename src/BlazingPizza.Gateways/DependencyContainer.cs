namespace BlazingPizza.Gateways;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaWebApiGateways
        (this IServiceCollection services, 
         EndpointsOptions endpointsOptions,
         Action<IHttpClientBuilder> httpClientConfiguration = null)
    {
        IHttpClientBuilder httpClientBuilder = services.AddHttpClient<IBlazingPizzaWebApiGateway, BlazingPizzaWebApiGateway>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(endpointsOptions.WebApiBaseAddress);
            return new BlazingPizzaWebApiGateway(httpClient, endpointsOptions);
        });
        httpClientConfiguration?.Invoke(httpClientBuilder);
        return services;
    } 
}