
using BlazingPizza.BussinesObjects.Agregates;

namespace BlazingPizza.Gateways;
public class BlazingPizzaWebApiGateway : IBlazingPizzaWebApiGateway
{
    readonly HttpClient Client;
    readonly EndpointsOptions EndpointsOptions;

    public BlazingPizzaWebApiGateway(HttpClient client, EndpointsOptions endpointsOptions)
    {
        Client = client;
        EndpointsOptions = endpointsOptions;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Client.GetFromJsonAsync<IReadOnlyCollection<PizzaSpecial>>(EndpointsOptions.Specials);
    }
    
    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Client.GetFromJsonAsync<IReadOnlyCollection<Topping>>(EndpointsOptions.Toppings);
    }

    public async Task<int> PlaceOrderAsync(Order order) 
    {                               
        HttpResponseMessage response = await Client.PostAsJsonAsync(EndpointsOptions.Order, order);
        return await response.Content.ReadFromJsonAsync<int>();
    }
}
