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

    public static IApplicationBuilder UseHttpExceptionMiddlerware(this IApplicationBuilder app, 
        IHostEnvironment environment, IHttpExceptionHandlerHub hub)
    {
        app.Use((context, next) => 
            HttpExceptionHandlerMiddleware.WriteResponse(context, environment.IsDevelopment(), hub));
        return app;
    }
}