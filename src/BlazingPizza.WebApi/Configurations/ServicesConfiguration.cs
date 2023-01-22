namespace BlazingPizza.WebApi.Configurations;

public static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddBlazingPizzaBackendServices(builder.Configuration.GetConnectionString("BlazingPizzaDb"), 
                                                        builder.Configuration["ImageBaseUrl"]);
        builder.Services.AddCors(options => 
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        return builder.Build();
    }
}
