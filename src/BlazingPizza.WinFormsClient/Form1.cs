using BlazingPizza.BussinesObjects.ValueObjects;
using Microsoft.Extensions.Configuration;

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
        services.AddBlazingPizzaFrontendServices(configuration.GetSection("BlazzingPizzaEndpoint").Get<EndpointsOptions>());
        blazorWebView1.HostPage = "wwwroot/index.html";
        blazorWebView1.RootComponents.Add<Razor.Views.Pages.Index>("#app");
        blazorWebView1.Services = services.BuildServiceProvider();
    }
}