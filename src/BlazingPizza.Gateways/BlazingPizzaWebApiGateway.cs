using CustomExceptions;
using System.Text.Json;

namespace BlazingPizza.Gateways;
internal sealed class BlazingPizzaWebApiGateway : IBlazingPizzaWebApiGateway
{
    readonly HttpClient Client;
    readonly EndpointsOptions EndpointsOptions;

    public BlazingPizzaWebApiGateway(HttpClient client, IOptions<EndpointsOptions> endpointsOptions)
    {
        Client = client;
        EndpointsOptions = endpointsOptions.Value;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync() => 
        await Client.GetFromJsonAsync<IReadOnlyCollection<PizzaSpecial>>(EndpointsOptions.Specials);

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync() => 
        await Client.GetFromJsonAsync<IReadOnlyCollection<Topping>>(EndpointsOptions.Toppings);

    public async Task<int> PlaceOrderAsync(Order order) 
    {
        int orderId = 0;
        HttpResponseMessage response = await Client.PostAsJsonAsync(EndpointsOptions.PlaceOrder, (PlaceOrderOrderDto)order);
        if(response.IsSuccessStatusCode)
        {
            orderId = await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new ProblemDetailsException(await response.Content.ReadFromJsonAsync<JsonElement>());
        }
        return orderId;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync() =>
        await Client.GetFromJsonAsync<IReadOnlyCollection<GetOrdersDto>>(EndpointsOptions.GetOrders);
    public async Task<GetOrderDto> GetOrderAsync(int id) =>
        await Client.GetFromJsonAsync<GetOrderDto>($"{EndpointsOptions.GetOrder}/{id}");
}
