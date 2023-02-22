using BlazingPizza.BussinesObjects.ValueObjects.Options;

namespace BlazingPizza.WinFormsClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        RegisterServices();
    }


    void RegisterServices()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();   
        services.AddSingleton<IConfiguration>(configuration);
        services.AddBlazingPizzaBackendServices(configuration.GetConnectionString("BlazingPizzaDb"),
                                                configuration["ImageBaseUrl"]); 
        services.AddBlazingPizzaFrontendServices(configuration.GetSection("BlazzingPizzaEndpoint").Get<EndpointsOptions>());
        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.RootComponents.Add<App>("#app");
        blazorWebView1.Services = services.BuildServiceProvider();
    }
}