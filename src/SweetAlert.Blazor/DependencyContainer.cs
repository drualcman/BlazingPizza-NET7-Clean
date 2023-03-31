﻿using Microsoft.Extensions.DependencyInjection;

namespace SweetAlert.Blazor;
public static class DependencyContainer
{
    public static IServiceCollection AddSweetAlertService(this IServiceCollection services)
    {
        services.AddSingleton<SweetAlertService>();
        return services;
    }
}