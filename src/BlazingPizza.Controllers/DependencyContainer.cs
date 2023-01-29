﻿namespace BlazingPizza.Controllers;

public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsController, GetSpecialController>();
        services.AddScoped<IGetToppingsController, GetToppingsController>();
        return services;
    }
}
