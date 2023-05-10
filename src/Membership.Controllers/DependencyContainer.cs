﻿namespace Membership.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddMemberShipControlleresServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterController, RegisterController>();
        services.AddScoped<ILoginController, LoginController>();
        return services;
    }
}