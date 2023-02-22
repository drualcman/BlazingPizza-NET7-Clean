using BlazingPizza.BussinesObjects.ValueObjects.Options;

namespace BlazingPizza.WebApi.Configurations;

public static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<SpecialsOptions>(builder.Configuration.GetSection(SpecialsOptions.SectionKey));

        builder.Services.AddBlazingPizzaBackendServices(builder.Configuration.GetConnectionString("BlazingPizzaDb"));
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
