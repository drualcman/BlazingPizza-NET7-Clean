namespace CustomExceptions.HttpHandlers;
public static class DependencyContainer
{
    public static IServiceCollection AddExceptionHandlers(this IServiceCollection services, Assembly exceptionHandlerAssembly)
    {
        services.AddSingleton<IHttpExceptionHandlerHub>(p => new HttpExceptionHandlerHub(exceptionHandlerAssembly));
        return services;
    }

    public static IServiceCollection AddExceptionHandlers(this IServiceCollection services) =>
        AddExceptionHandlers(services, Assembly.GetExecutingAssembly());

    public static IApplicationBuilder UseHttpExceptionHandler(this IApplicationBuilder app)
    {
          app.UseExceptionHandler(builder =>
            builder.UseHttpExceptionMiddlerware(app.ApplicationServices.GetRequiredService<IHostEnvironment>(), 
                                                app.ApplicationServices.GetRequiredService<IHttpExceptionHandlerHub>()));

        return app;
    }

    internal static IApplicationBuilder UseHttpExceptionMiddlerware(this IApplicationBuilder app, 
        IHostEnvironment environment, IHttpExceptionHandlerHub hub)
    {
        app.Use((context, next) =>
            HttpExceptionHandlerMiddleware.WriteResponse(context, environment.IsDevelopment(), hub, next));
        return app;
    }
    
}