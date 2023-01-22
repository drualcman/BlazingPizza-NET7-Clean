using BlazingPizza.WebApi.Configurations;

await WebApplication.CreateBuilder(args)
              .ConfigureWebApiServices()
              .ConfigureWebApiMiddlewares()
              .RunAsync();
