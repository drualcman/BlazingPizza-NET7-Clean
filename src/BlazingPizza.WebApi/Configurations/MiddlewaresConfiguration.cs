﻿namespace BlazingPizza.WebApi.Configurations;

public static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseSpecialsEndpoints();
        app.UseToppingsEndpoints();
        app.UseOrdersEndpoints();
        app.UseCors();
        return app;
    }
}
