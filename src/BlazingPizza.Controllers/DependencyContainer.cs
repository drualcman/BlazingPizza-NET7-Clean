using BlazingPizza.Backend.BussinesObjects.Interfaces.GetOrder;
using BlazingPizza.Backend.BussinesObjects.Interfaces.GetOrders;
using BlazingPizza.Backend.BussinesObjects.Interfaces.GetSpecials;
using BlazingPizza.Backend.BussinesObjects.Interfaces.GetToppings;
using BlazingPizza.Backend.BussinesObjects.Interfaces.PlaceOrder;

namespace BlazingPizza.Controllers;

public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsController, GetSpecialController>();
        services.AddScoped<IGetToppingsController, GetToppingsController>();
        services.AddScoped<IPlaceOrderController, PlaceOrderController>();
        services.AddScoped<IGetOrdersController, GetOrdersController>();
        services.AddScoped<IGetOrderController, GetOrderController>();
        return services;
    }
}
