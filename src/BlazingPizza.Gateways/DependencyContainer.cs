using HttpMessageHandlers;
using Membership.Blazor.Entities.Interfaces;

namespace BlazingPizza.Gateways;

public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaWebApiGateways
        (this IServiceCollection services,
         IOptions<EndpointsOptions> endpointsOptions,
         Action<IHttpClientBuilder> httpClientConfiguration = null)
    {
        IHttpClientBuilder httpClientBuilder = services.AddHttpClient<IBlazingPizzaWebApiGateway, BlazingPizzaWebApiGateway>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(endpointsOptions.Value.WebApiBaseAddress);            
            return new BlazingPizzaWebApiGateway(httpClient, endpointsOptions);
        })
            .AddHttpMessageHandler(() => new ExceptionDelegatingHandler());
        httpClientConfiguration?.Invoke(httpClientBuilder);
        return services;
    }
}